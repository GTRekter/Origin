using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Origin.Models.Store
{
    public class OR_Role : IdentityRole<int>
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required(ErrorMessage = "A name is required")]
        private string _name;

        #endregion

        #region Properties

        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid name");
                }
                else
                {
                    _name = value;
                }
            }
        }

        #endregion
    }
}