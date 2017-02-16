using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Snippet { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public Storage Storage { get; set; }
    }
}