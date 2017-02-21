using PhoneCat.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class HardwareDTO
    {
        public int Id { get; set; }
        public bool Accelerometer { get; set; }
        public bool FmRadio { get; set; }
        public bool PhysicalKeyboard { get; set; }
        [DoubleValidator(ErrorMessage = "Audio Jack field must be a double")]
        public string AudioJack { get; set; }
        [Required]
        public string Processor { get; set; }
        [Required]
        public string Usb { get; set; }
    }
}