using System;

namespace Origin.Models
{
    public class Item
    {
        public string Id { get; set; }

        public string OriginId { get; set; }

        public string Type { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LateEditDate { get; set; }

    }
}