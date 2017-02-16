using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class AndroidOs
    {
        public int Id { get; set; }
        public string Version { get; set; }

        public virtual ICollection<Android> Androids { get; set; }
    }
}