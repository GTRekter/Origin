using Origin.ViewModels;
using System.Collections.Generic;

namespace Origin.ViewModels.Responses
{
    public class GetItemResponse : Base
    {
        public ItemDetails Item { get; set; }

        public class ItemDetails
        {
            public int Id { get; set; }

            public string ItemTypeOriginId { get; set; }

            public string OriginId { get; set; }

            public string CreationDate { get; set; }

            public string LastEditDate { get; set; }

            public List<Property> Properties { get; set; }
            
        }

        public class Property
        {
            public int Id { get; set; }

            public string OriginId { get; set; }

            public string Name { get; set; }

            public string Value { get; set; }
        }
    }
}
