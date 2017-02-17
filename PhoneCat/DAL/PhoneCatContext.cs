using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PhoneCat.Models;

namespace PhoneCat.DAL
{
    public class PhoneCatContext : DbContext
    {
        public PhoneCatContext() : base("PhoneCatContext") { }
        public DbSet<Phone> Phones {get; set;}
        public DbSet<Image> Images { get; set; }
        public DbSet<AndroidOs> AndroidOs { get; set; }
        public DbSet<AndroidUi> AndroidUi { get; set; }
        public DbSet<BatteryType> BatteryTypes { get; set; }
    }
}