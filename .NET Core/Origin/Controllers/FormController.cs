using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Origin.ViewModels.Requests;

namespace Origin.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        //IFormService service = new FormService();

        [HttpPost]
        public JsonResult GetForm(GetFormRequest request)
        {
            //var viewModel = service.GetForm(request);
            //return Json(viewModel, JsonRequestBehavior.DenyGet);
            return null;
        }
    }
}