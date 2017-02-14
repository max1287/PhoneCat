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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>()
                .HasMany(i => i.Images).WithMany(p => p.Phones)
                .Map(t => t.MapLeftKey("PhoneID")
                    .MapRightKey("ImageID")
                    .ToTable("PhoneImage"));
        }

    }
}