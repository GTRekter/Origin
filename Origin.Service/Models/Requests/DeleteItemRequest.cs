using System.Collections.Generic;

namespace Origin.Service.Models.Requests
{
    public class DeleteItemRequest : Base
    {

        public List<string> OriginIds { get; set; }
    }
}
