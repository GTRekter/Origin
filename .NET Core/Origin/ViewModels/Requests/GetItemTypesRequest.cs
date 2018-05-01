using Origin.ViewModels;

namespace Origin.ViewModels.Requests
{
    public class GetItemTypesRequest : Base
    {
        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
