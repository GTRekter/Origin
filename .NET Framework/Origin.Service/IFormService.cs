using Origin.Service.Models.Requests;
using Origin.Service.Models.Responses;

namespace Origin.Service
{
    public interface IFormService
    {

        GetFormResponse GetForm(GetFormRequest request);

    }
}
