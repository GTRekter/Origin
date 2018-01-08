using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Models.Store
{
    public class OR_Form
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _id;
        private Guid _originId;
        private string _name;
        private string _type;

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

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
    }
}
