using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Models.Store
{
    public class OR_Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _id;
        private Guid _originId;
        private Guid _itemTypeOriginId;
        private DateTime _creationDate;
        private DateTime _lastEditDate;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public Guid OriginId
        {
            get
            {
                return _originId;
            }
            set
            {
                _originId = value;
            }
        }

        public Guid ItemTypeOriginId
        {
            get
            {
                return _itemTypeOriginId;
            }
            set
            {
                _itemTypeOriginId = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return _creationDate;
            }
            set
            {
                _creationDate = value;
            }
        }

        public DateTime LastEditDate
        {
            get
            {
                return _lastEditDate;
            }
            set
            {
                _lastEditDate = value;
            }
        }
    }
}