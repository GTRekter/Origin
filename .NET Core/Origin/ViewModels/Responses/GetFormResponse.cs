using Origin.ViewModels;
using System.Collections.Generic;

namespace Origin.ViewModels.Responses
{
    public class GetFormResponse : Base
    {
        public string Name { get; set; }

        public List<Input> Inputs { get; set; }

        public class Input
        {
            public int Id { get; set; }

            public string OriginId { get; set; }

            public string Name { get; set; }

            public string Required { get; set; }

            public string Type { get; set; }

            public List<string> Values { get; set; }
        }
    }
}
