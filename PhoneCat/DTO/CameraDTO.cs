using PhoneCat.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class CameraDTO
    {
        [DoubleValidator(ErrorMessage = "Primary field must be a double!")]
        public string Primary { get; set; }
    }
}