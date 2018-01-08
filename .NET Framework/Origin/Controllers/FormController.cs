using System.Web.Mvc;
using Origin.Service;
using Origin.Service.Models.Requests;

namespace Origin.Controllers
{
    public class FormController : Controller
    {
        IFormService service = new FormService();

        [HttpPost]
        public JsonResult GetForm(GetFormRequest request)
        {
            var viewModel = service.GetForm(request);
            return Json(viewModel, JsonRequestBehavior.DenyGet);
        }
    }
}