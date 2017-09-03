namespace Origin.Service.Models.Requests
{
    public class GetFormRequest : Base
    {
        public string ActionName { get; set; }

        public string ItemType { get; set; }
    }
}
