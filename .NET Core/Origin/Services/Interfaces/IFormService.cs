using Origin.ViewModels.Requests;
using Origin.ViewModels.Responses;

namespace Origin.Service.Interfaces
{
    interface IFormService
    {
        GetFormResponse GetForm(GetFormRequest request);
    }
}
