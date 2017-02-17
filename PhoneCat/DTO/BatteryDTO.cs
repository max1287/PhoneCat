using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class BatteryDTO
    {
        public int Id { get; set; }
        public int StandbyTime { get; set; }
        public int TalkTime { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
        public int Capacity { get; set; }
    }
}