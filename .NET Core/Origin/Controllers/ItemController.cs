using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Origin.ViewModels.Requests;

namespace Origin.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        //IItemService service = new ItemService();

        //[HttpPost]
        //public JsonResult AddItem(AddItemRequest request)
        //{
        //    var viewModel = service.AddItem(request);
        //    return Json(viewModel, JsonRequestBehavior.DenyGet);
        //}

        //[HttpPost]
        //public JsonResult GetItem(GetItemRequest request)
        //{
        //    var viewModel = service.GetItem(request);
        //    return Json(viewModel, JsonRequestBehavior.DenyGet);
        //}

        //[HttpPost]
        //public JsonResult GetItems(GetItemsRequest request)
        //{
        //    var viewModel = service.GetItems(request);
        //    return Json(viewModel, JsonRequestBehavior.DenyGet);
        //}

        //[HttpPost]
        //public JsonResult DeleteItem(DeleteItemRequest request)
        //{
        //    var viewModel = service.DeleteItems(request);
        //    return Json(viewModel, JsonRequestBehavior.DenyGet);
        //}
    }
}