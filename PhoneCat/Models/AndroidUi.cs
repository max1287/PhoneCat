using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class AndroidUi
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }
}