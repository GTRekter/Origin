using System.Collections.Generic;

namespace Origin.Service.Models.Responses
{
    public class GetLookupResponse
    {
        public string Name { get; set; }

        public IEnumerable<string> Values { get; set; }
    }
}
