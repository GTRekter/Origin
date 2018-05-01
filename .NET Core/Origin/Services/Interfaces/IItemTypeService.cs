using Origin.ViewModels.Requests;
using Origin.ViewModels.Responses;
using Origin.ViewModels;

namespace Origin.Service.Interfaces
{
    interface IItemTypeService
    {
        GetItemsResponse GetItemTypes(GetItemTypesRequest request);
    }
}
