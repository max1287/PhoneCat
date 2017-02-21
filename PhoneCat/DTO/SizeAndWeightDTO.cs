using PhoneCat.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class SizeAndWeightDTO
    {
        [DoubleValidator(ErrorMessage = "Height must be a double!")]
        public string Height { get; set; }
        [DoubleValidator(ErrorMessage = "Width must be a double!")]
        public string Width { get; set; }
        [DoubleValidator(ErrorMessage = "Depth must be a double!")]
        public string Depth { get; set; }
        [DoubleValidator(ErrorMessage = "Weight must be a double!")]
        public string Weight { get; set; }
    }
}