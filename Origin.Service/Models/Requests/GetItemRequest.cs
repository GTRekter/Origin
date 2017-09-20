namespace Origin.Service.Models.Requests
{
    public class GetItemRequest : Base
    {

        public string OriginId { get; set; }

        public string ItemTypeOriginId { get; set; }
    }
}
