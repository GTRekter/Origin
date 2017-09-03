using System.Web.Mvc;
using Origin.Service;
using Origin.Service.Implementation;

namespace Origin.Controllers
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