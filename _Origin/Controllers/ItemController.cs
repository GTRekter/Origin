using System.Web.Mvc;
using FileExtractor.Service;
using FileExtractor.Service.Models.Requests;

namespace FileExtractor.Controllers
{
    public class ItemController : Controller
    {
        IItemService service = new ItemService();

        [HttpPost]
        public JsonResult GetItems(GetItemsRequest request)
        {
            var viewModel = service.GetItems(request);
            return Json(viewModel, JsonRequestBehavior.DenyGet);
        }

    }
}