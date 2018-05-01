using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Origin.Service.Implementation;


namespace Origin.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly CacheService _cacheService;

        #region Constructor

        public ConfigurationController(IMemoryCache cache)
        {  
            _cacheService = new CacheService(cache, GetConfigurationByPath("Paths:Localization"));
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public JsonResult GetLocalizations()
        {
            var viewModel = _cacheService.GetLocalizations();
            return Json(viewModel);
        }

        [HttpGet]
        public JsonResult GetConfiguration()
        {
            var viewModel = _cacheService.GetConfiguration();
            return Json(viewModel);
        }

        #endregion

        #region Private Methods

        public string GetConfigurationByPath(string path)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot Configuration; Configuration = builder.Build();

            return Configuration.GetValue<string>(path);
        }

        #endregion
    }
}