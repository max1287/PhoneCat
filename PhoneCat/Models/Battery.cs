using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class Battery
    {
        public int StandbyTime { get; set; }
        public int TalkTime { get; set; }
        public int Capacity { get; set; }
    }
}