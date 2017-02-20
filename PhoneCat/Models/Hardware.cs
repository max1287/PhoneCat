using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class Hardware
    {
        public bool Accelerometer { get; set; }
        public bool FmRadio { get; set; }
        public bool PhysicalKeyboard { get; set; }
        public double AudioJack { get; set; }
    }
}