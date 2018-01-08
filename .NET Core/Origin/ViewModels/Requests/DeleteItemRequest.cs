using Origin.ViewModels;
using System.Collections.Generic;

namespace Origin.ViewModels.Requests
{
    public class DeleteItemRequest : Base
    {

        public List<string> OriginIds { get; set; }
    }
}
