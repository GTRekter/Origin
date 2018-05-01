using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.Models.Store
{
    public class OR_PropertyValue
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid ItemOriginId { get; set; }

        [Required]
        public Guid PropertyOriginId { get; set; }

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
