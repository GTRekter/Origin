using Origin.ViewModels;

namespace Origin.ViewModels.Requests
{
    public class GetItemRequest : Base
    {

        public string OriginId { get; set; }

        public string ItemTypeOriginId { get; set; }
    }
}
