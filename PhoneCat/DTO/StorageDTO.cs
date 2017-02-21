using PhoneCat.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class StorageDTO
    { 
        [IntegerValidator(ErrorMessage = "Flash memory must be an integer!")]
        public string Flash { get; set; }
        [IntegerValidator(ErrorMessage = "RAM memory must be an integer!")]
        public string Ram { get; set; }
    }
}