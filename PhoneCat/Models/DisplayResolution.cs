using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class DisplayResolution
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}