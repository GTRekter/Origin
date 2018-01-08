using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Origin.Models.Store
{
    public class OR_Role : IdentityRole<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private Guid _id;
        private string _name;

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

        public override string Name
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