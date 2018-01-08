using Origin.ViewModels;
using System.Collections.Generic;

namespace Origin.ViewModels.Responses
{
    public class GetItemsResponse : Base
    {
        public List<Header> Headers { get; set; }

        public List<Item> Items { get; set; }

        public class Header
        {
            public string Name { get; set; }
        }

        public class Item
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
