using System;
using System.Configuration;
using NLog;
using StackExchange.Redis;

namespace Units.Data
{
    public interface ICacher
    {
        T Get<T>(string key, Func<T> getter, int? timeout = null) where T : class;
        bool Connected { get; }
        void Clear(string key);
    }

    public class RedisCache : ICacher
    {
        private readonly ILogger _logger;
        private ConnectionMultiplexer redis;
        private DateTime lastError;

        private static bool Enable => bool.Parse(ConfigurationManager.AppSettings["RedisEnable"] ?? "true");
        private static string Host => ConfigurationManager.AppSettings["RedisHost"] ?? "localhost";
        private static int RetryCooldown => int.Parse(ConfigurationManager.AppSettings["RedisRetryCooldown"] ?? "10");
        private static int Lifetime => int.Parse(ConfigurationManager.AppSettings["RedisLifetime"] ?? "60");

        public bool Connected => DB != null;

        private IDatabase DB
        {
            get
            {
                try
                {
                    return (redis = redis ?? ConnectionMultiplexer.Connect(Host)).GetDatabase();
                }
                catch(RedisConnectionException ex)
                {
                    _logger.Warn(ex, $"Can't connect to Redis at {Host}: {ex.Message}");
                    lastError = DateTime.UtcNow;
                    return null;
                }
            }
        }

        public RedisCache(ILogger logger)
        {
            _logger = logger;
        }

        public void Clear(string key)
        {
            DB.KeyDelete(key);
        }

        public T Get<T>(string key, Func<T> getter, int? lifetime = null) where T : class
        {
            if (!Enable || DateTime.UtcNow - lastError < TimeSpan.FromSeconds(RetryCooldown) || DB == null)
            {
                return getter();
            }

            var rv = default(T);
            try
            {
                if (DB.KeyExists(key))
                {
                    return DB.StringGet(key).ToString().FromJson<T>();
                }

                rv = getter();
                DB.StringSet(key, rv.ToJson(), TimeSpan.FromSeconds(lifetime ?? Lifetime));
                return rv;
            }
            catch(RedisConnectionException ex)
            {
                _logger.Warn(ex, $"Redis connection error: {ex.Message}");
                lastError = DateTime.UtcNow;
                return rv == default(T) ? getter() : rv;
            }
        }
    }
}
