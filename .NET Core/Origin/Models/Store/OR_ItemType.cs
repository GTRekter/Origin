using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Models.Store
{
    public class OR_ItemType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _id;
        private Guid _originId;
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
