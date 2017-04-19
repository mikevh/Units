using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Units.Data;

namespace Units.Controllers
{
    public class StatusController : Controller
    {
        private readonly ICacher _cacher;
        private DbContext _dbContext;

        public StatusController(ICacher cache, DbContext db)
        {
            _dbContext = db;
            _cacher = cache;
        }

        public async Task<ActionResult> Index()
        {
            var dbStatus = "<empty>";
            try
            {
                await _dbContext.Database.Connection.OpenAsync();
                var state = _dbContext.Database.Connection.State;
                _dbContext.Database.Connection.Close();
                dbStatus = "Ok";
            }
            catch(Exception e)
            {
                dbStatus = e.Message;
            }

            var vm = new StatusVM
            {
                CacheConnected = _cacher.Connected,
                DefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString ?? "<empty",
                RedisHost = ConfigurationManager.AppSettings["RedisHost"] ?? "<empty>",
                Build = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion,
                Environment = ConfigurationManager.AppSettings["Env"] ?? "<empty>",
                DBStatus = dbStatus
            };

            return View(vm);
        }
    }

    public class StatusVM
    {
        public bool CacheConnected { get; set; }
        public string DBStatus { get; set; }
        public string DefaultConnection { get; set; }
        public string RedisHost { get; set; }
        public string Build { get; set; }
        public string Environment { get; set; }
    }
}
