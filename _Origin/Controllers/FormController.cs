using System.Web.Mvc;
using FileExtractor.Service;
using FileExtractor.Service.Models.Requests;

namespace FileExtractor.Controllers
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