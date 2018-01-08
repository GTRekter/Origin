using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Origin.Models.Store
{
    public class OR_User : IdentityUser<Guid>
    {
        #region Constructor

        public OR_User()
        {
            this.EmailConfirmed = false;
            this.PhoneNumberConfirmed = false;
        }

        #endregion

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private Guid _id;
        [StringLength(255), Required]
        private string _name;
        [StringLength(255), Required]
        private string _surname;
        [StringLength(50), Required]
        private string _phoneNumber;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        private bool _phoneNumberConfirmed;
        [Required]
        private string _email;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        private bool _emailConfirmed;
        [Required]
        private string _passwordHash;

        public override Guid Id
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

        public override string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }

        public override bool PhoneNumberConfirmed
        {
            get
            {
                return _phoneNumberConfirmed;
            }
            set
            {
                _phoneNumberConfirmed = value;
            }
        }

        public override string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public override bool EmailConfirmed
        {
            get
            {
                return _emailConfirmed;
            }
            set
            {
                _emailConfirmed = value;
            }
        }

        public override string PasswordHash
        {
            get
            {
                return _passwordHash;
            }
            set
            {
                _passwordHash = value;
            }
        }
    }
}