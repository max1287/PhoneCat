using PhoneCat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class PhoneDetailDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Snippet { get; set; }
        public List<string> Images { get; set; }

        public Storage Storage { get; set; }
        public SizeAndWeight SizeAndWeight { get; set; }
    }
}