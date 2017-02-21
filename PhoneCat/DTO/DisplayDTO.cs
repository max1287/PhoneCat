using PhoneCat.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class DisplayDTO
    {
        [DoubleValidator(ErrorMessage = "Screen size must be a double!")]
        public string ScreenSize { get; set; }
        public bool TouchScreen { get; set; }
        [Required]
        public string Resolution { get; set; }
        public string Name { get; set; }
    }
}