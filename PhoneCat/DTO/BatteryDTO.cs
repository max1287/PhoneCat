using PhoneCat.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class BatteryDTO
    {
        [IntegerValidator(ErrorMessage = "Standby Time must be an integer")]
        public string StandbyTime { get; set; }
        [IntegerValidator(ErrorMessage = "Talk Time must be an integer")]
        public string TalkTime { get; set; }
        [Required]
        public string Type { get; set; }
        public string TypeName { get; set; }
        [IntegerValidator(ErrorMessage = "Capacity must be an integer")]
        public string Capacity { get; set; }
    }
}