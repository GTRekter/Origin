using Origin.ViewModels;
using System.Collections.Generic;

namespace Origin.ViewModels.Responses
{
    public class GetLookupResponse
    {
        public string Name { get; set; }

        public IEnumerable<string> Values { get; set; }
    }
}
