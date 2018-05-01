using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Origin.Models.Store
{
    public class OR_User : IdentityUser<int>
    {
        #region Constructor

        public OR_User()
        {
            this.EmailConfirmed = false;
            this.PhoneNumberConfirmed = false;
        }

        #endregion

        #region Fields

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public Guid OriginId { get; set; }

        //[StringLength(255), Required]
        private string _name;

        //[StringLength(255), Required]
        private string _surname;

        [Phone]
        public override string PhoneNumber { get; set; }

        [EmailAddress, Required]
        public override string Email { get; set; }

        [Required]
        public override string PasswordHash { get; set; }

        #endregion

        #region Properties

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

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }

        #endregion
    }
}