using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class BatteryType
    {
        public int Id { get; set; }
        public string BatteryTypeName { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}