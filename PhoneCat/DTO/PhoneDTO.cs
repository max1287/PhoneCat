﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.DTO
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Snippet { get; set; }
        public string ImageUrl { get; set; }
    }
}