using Newtonsoft.Json;

namespace System
{
    public static class JsonExtensions
    {
        public static string ToJson<T>(this T obj, Formatting formatting = Formatting.None) => JsonConvert.SerializeObject(obj, formatting);

        public static T FromJson<T>(this string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
