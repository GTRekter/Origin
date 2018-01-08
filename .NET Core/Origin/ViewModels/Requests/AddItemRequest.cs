using Origin.ViewModels;
using System.Collections.Generic;

namespace Origin.ViewModels.Requests
{
    public class AddItemRequest : Base
    {
        public string ItemType { get; set; }

        public List<Input> Inputs { get; set; }

        public class Input
        {
            public string Name { get; set; }

            public string Value { get; set; }
        }
    }
}