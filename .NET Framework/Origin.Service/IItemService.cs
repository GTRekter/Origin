using Origin.Service.Models;
using Origin.Service.Models.Requests;
using Origin.Service.Models.Responses;

namespace Origin.Service
{
    public interface IItemService
    {
        Base AddItem(AddItemRequest request);

        GetItemResponse GetItem(GetItemRequest request);

        GetItemsResponse GetItems(GetItemsRequest request);

        Base DeleteItems(DeleteItemRequest request);

    }
}
