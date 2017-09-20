using System.Web.Mvc;
using Origin.Service;
using Origin.Service.Implementation;

namespace Origin.Controllers
{
    public class ConfigurationController : Controller
    {
        ILocalizationService service = new LocalizationService();
        ICacheService cacheService = new CacheService();

        [HttpGet]
        public JsonResult GetLocalizations()
        {
            var viewModel = cacheService.GetLocalizations();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetConfiguration()
        {
            var viewModel = cacheService.GetConfiguration();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}