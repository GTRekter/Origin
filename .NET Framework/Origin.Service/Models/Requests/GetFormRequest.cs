namespace Origin.Service.Models.Requests
{
    public class GetFormRequest : Base
    {
        public string ActionName { get; set; }

        public string ItemTypeOriginId { get; set; }
    }
}
