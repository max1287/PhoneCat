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
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<DisplayResolution> DisplayResolutions { get; set; }
        public DbSet<CameraFeatures> CameraFeatures { get; set; }
        public DbSet<Bluetooth> Blueteeth { get; set; }
        public DbSet<Wifi> Wifis { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Usb> Usb { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>()
                .HasMany(p=>p.Availability).WithMany(i => i.Phones)
                .Map(t => t.MapLeftKey("PhoneId")
                    .MapRightKey("AvailabilityId")
                    .ToTable("PhoneAvailability"));
            modelBuilder.Entity<Phone>()
                .HasMany(p => p.CameraFeatures).WithMany(i => i.Phones)
                .Map(t => t.MapLeftKey("PhoneId")
                .MapRightKey("FeaturesId")
                .ToTable("PhoneCameraFeatures"));
            modelBuilder.Entity<Phone>()
                .HasMany(p => p.Wifi).WithMany(i => i.Phones)
                .Map(t => t.MapLeftKey("PhoneId")
                .MapRightKey("WifiId")
                .ToTable("PhoneWifi"));
        }
    }
}