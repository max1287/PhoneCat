using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class AndroidDTO
    {
        [Required]
        public string Os { get; set; }
        [Required]
        public string Ui { get; set; }
    }
}