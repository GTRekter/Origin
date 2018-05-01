using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Models.Store
{
    public class OR_LookupValue
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid OriginId { get; set; }

        [Required]
        public Guid LookupOriginId { get; set; }

        [Required(ErrorMessage = "A value is required")]
        private string _value;

        #endregion

        #region Properties

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid value");
                }
                else
                {
                    _value = value;
                }
            }
        }

        #endregion
    }
}
