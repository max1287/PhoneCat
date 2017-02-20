using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class Connectivity
    {
        public bool Gps { get; set; }
        public bool Infrared { get; set; }
        public string Cell { get; set; }
    }
}