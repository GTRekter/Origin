using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Models.Store
{
    public class OR_ItemAction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _id;
        private Guid _originId;
        private Guid _itemTypeOriginId;
        private Guid _formOriginId;
        private string _name;

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

        public Guid FormOriginId
        {
            get
            {
                return _formOriginId;
            }
            set
            {
                _formOriginId = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
