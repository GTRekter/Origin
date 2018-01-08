using Origin.ViewModels.Requests;
using Origin.ViewModels.Responses;
using Origin.ViewModels;

namespace Origin.Service.Interfaces
{
    interface IItemService
    {
        Base AddItem(AddItemRequest request);

        GetItemResponse GetItem(GetItemRequest request);

        GetItemsResponse GetItems(GetItemsRequest request);

        Base DeleteItems(DeleteItemRequest request);
    }
}
