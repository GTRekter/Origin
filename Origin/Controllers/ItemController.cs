using System.Web.Mvc;
using Origin.Service;
using Origin.Service.Models.Requests;

namespace Origin.Controllers
{
    public class ItemController : Controller
    {
        IItemService service = new ItemService();

        [HttpPost]
        public JsonResult AddItem(AddItemRequest request)
        {
            var viewModel = service.AddItem(request);
            return Json(viewModel, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetItems(GetItemsRequest request)
        {
            var viewModel = service.GetItems(request);
            return Json(viewModel, JsonRequestBehavior.DenyGet);
        }

    }
}