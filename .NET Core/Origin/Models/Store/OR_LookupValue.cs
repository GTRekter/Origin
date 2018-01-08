using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Models.Store
{
    public class OR_LookupValue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _id;
        private Guid _originId;
        private Guid _relatedOriginId;
        private string _value;

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

        public Guid RelatedOriginId
        {
            get
            {
                return _relatedOriginId;
            }
            set
            {
                _relatedOriginId = value;
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}
