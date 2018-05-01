﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Origin.Models.Enums;

namespace Origin.Models.Store
{
    public class OR_Input
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid OriginId { get; set; }

        [Required]
        public Guid FormOriginId { get; set; }

        public InputType Type { get; set; }

        [Required(ErrorMessage = "A name is required")]
        private string _name;

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
