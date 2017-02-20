using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class Bluetooth
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public ICollection<Phone> Phones { get; set; }
    }
}