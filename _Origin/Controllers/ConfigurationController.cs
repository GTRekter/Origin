using System.Web.Mvc;
using FileExtractor.Service;
using FileExtractor.Service.Implementation;

namespace FileExtractor.Controllers
{
    public class ConfigurationController : Controller
    {
        ILocalizationService service = new LocalizationService();
        ICacheService cacheService = new CacheService();

        [HttpPost]
        public JsonResult GetLocalizations()
        {
            var viewModel = cacheService.GetLocalizations();
            return Json(viewModel, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetConfiguration()
        {
            var viewModel = cacheService.GetConfiguration();
            return Json(viewModel, JsonRequestBehavior.DenyGet);
        }
    }
}