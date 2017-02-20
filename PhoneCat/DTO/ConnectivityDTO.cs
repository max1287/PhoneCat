using PhoneCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class ConnectivityDTO
    {
        public bool Gps { get; set; }
        public bool Infrared { get; set; }
        public string Cell { get; set; }
        public string Bluetooth { get; set; }
        public List<string> Wifi { get; set; }
    }
}