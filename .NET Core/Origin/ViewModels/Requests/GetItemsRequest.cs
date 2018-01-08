using Origin.ViewModels;

namespace Origin.ViewModels.Requests
{
    public class GetItemsRequest : Base
    {

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string ItemTypeOriginId { get; set; }
    }
}
