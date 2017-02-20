using System;
using System.Collections.Generic;
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
        public double AudioJack { get; set; }
        public string Processor { get; set; }
        public string Usb { get; set; }
    }
}