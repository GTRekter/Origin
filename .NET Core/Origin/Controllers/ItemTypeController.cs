using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Origin.Models;
using Origin.Service.Implementation;
using Origin.ViewModels.Requests;

namespace Origin.Controllers
{
    [Authorize]
    public class ItemTypeController : Controller
    {
        private readonly OriginDbContext _context;

        private readonly ItemTypeService _service;

        public ItemTypeController(OriginDbContext context)
        {
            _context = context;
            _service = new ItemTypeService(context);
        }

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

        [HttpPost]
        public JsonResult GetItemTypes(GetItemTypesRequest request)
        {
            var viewModel = _service.GetItemTypesToList(request);
            return Json(viewModel);
        }

        //[HttpPost]
        //public JsonResult DeleteItem(DeleteItemRequest request)
        //{
        //    var viewModel = service.DeleteItems(request);
        //    return Json(viewModel, JsonRequestBehavior.DenyGet);
        //}
    }
}