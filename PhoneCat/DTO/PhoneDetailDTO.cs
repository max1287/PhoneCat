using PhoneCat.Models;
using PhoneCat.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class PhoneDetailDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Name field can not be empty!")]
        public string Name { get; set; }
        public string Description { get; set; }
        [IntegerValidator(ErrorMessage = "Age must be an integer!")]
        public string Age { get; set; }
        public string Snippet { get; set; }
        public string AdditionalFeatures { get; set; }
        public List<string> Images { get; set; }
        public StorageDTO Storage { get; set; }
        public SizeAndWeightDTO SizeAndWeight { get; set; }
        public AndroidDTO Android { get; set; }
        public BatteryDTO Battery { get; set; }
        public List<string> Availability { get; set; }
        public DisplayDTO Display { get; set; }
        public CameraDTO Camera { get; set; }
        public List<string> CameraFeatures { get; set; }
        public ConnectivityDTO Connectivity { get; set; }
        public HardwareDTO Hardware { get; set; }
    }
}