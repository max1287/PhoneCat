using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class DisplayDTO
    {
        public double ScreenSize { get; set; }
        public bool TouchScreen { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Name { get; set; }
    }
}