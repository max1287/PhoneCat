using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class Android
    {
        public int Id { get; set; }
        public AndroidOs Os { get; set; }
        public string Ui { get; set; }
    }
}