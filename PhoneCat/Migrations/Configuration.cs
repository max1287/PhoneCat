namespace PhoneCat.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhoneCatContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhoneCatContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var androidOs = new List<AndroidOs>
            {
                new AndroidOs {Version = "Android 2.1" },
                new AndroidOs {Version = "Android 2.2" },
                new AndroidOs {Version = "Android 2.3" }
            };
            androidOs.ForEach(a => context.AndroidOs.AddOrUpdate(s => s.Version, a));
            context.SaveChanges();

            var androidUi = new List<AndroidUi>
            {
                new AndroidUi {Name = "MOTOBLUR" },
                new AndroidUi {Name = "Android" },
                new AndroidUi {Name = "TouchWiz" },
                new AndroidUi {Name = "LG Home" }
            };
            androidUi.ForEach(a => context.AndroidUi.AddOrUpdate(s => s.Name, a));
            context.SaveChanges();

            var batteryTypes = new List<BatteryType>
            {
                new BatteryType {Type = "Li-Ion", BatteryTypeName = "Lithium Ion" },
                new BatteryType {Type = "Li-Pol", BatteryTypeName = "Lithium Polymer" },
                new BatteryType {Type = "NiCd", BatteryTypeName = "Nickel Cadmium" }
            };
            batteryTypes.ForEach(b => context.BatteryTypes.AddOrUpdate(s => s.Type, b));
            context.SaveChanges();

            var availabilities = new List<Availability>
            {
                new Availability {Name = "AT&T" },
                new Availability {Name = "T-Mobile" },
                new Availability {Name = "KT" },
                new Availability {Name = "O2" },
                new Availability {Name = "Orange" },
                new Availability {Name = "Singtel" },
                new Availability {Name = "StarHub" },
                new Availability {Name = "Vodafone" },
                new Availability {Name = "M1" }
            };
            availabilities.ForEach(a => context.Availabilities.AddOrUpdate(s => s.Name, a));
            context.SaveChanges();

            var phones = new List<Phone>
            {
                new Phone {Name = "LG-Axis", Age = 1,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 1000, TalkTime=5, Capacity = 1180},
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    AdditionalFeatures = "AdditionalFeatures 1",
                    Snippet ="Android Powered, Google Maps Navigation, 5 Customizable Home Screens", Description = "Android plus QWERTY is a powerful duo. LG Axis melds a speedy UI with the limitless micro-entertainment of 80,000+ apps including voice-activated Google. Feel the tactile vibration on its tempered glass touchscreen. Take the fuzziness out of your fun with a 3.2MP camera that does 360\u00b0 panoramics. And customize your home screens with shortcuts to your apps, favorites, and widgets. It's the centerpiece of your life."},
                new Phone {Name = "Nexus S", Age = 3,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 1000, TalkTime=5, Capacity = 245},
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    AdditionalFeatures = "AdditionalFeatures 2",
                    Snippet ="Fast just got faster with Nexus S. A pure Google experience, Nexus S is the first phone to run Gingerbread (Android 2.3), the fastest version of Android yet.", Description = "Nexus S is the next generation of Nexus devices, co-developed by Google and Samsung. The latest Android platform (Gingerbread), paired with a 1 GHz Hummingbird processor and 16GB of memory, makes Nexus S one of the fastest phones on the market. It comes pre-installed with the best of Google apps and enabled with new and popular features like true multi-tasking, Wi-Fi hotspot, Internet Calling, NFC support, and full web browsing. With this device, users will also be the first to receive software upgrades and new Google mobile apps as soon as they become available. For more details, visit http://www.google.com/nexus"},
                new Phone {Name = "Samsung Galaxy Tab\u2122", Age = 4,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 452, TalkTime=5, Capacity = 24521},
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    AdditionalFeatures = "AdditionalFeatures 3",
                    Snippet ="Feel Free to Tab\u2122. The Samsung Galaxy Tab\u2122 brings you an ultra-mobile entertainment experience through its 7\u201d display, high-power processor and Adobe\u00ae Flash\u00ae Player compatibility", Description = "Feel Free to Tab\u2122. The Samsung Galaxy Tab\u2122, the tablet device that delivers enhanced capabilities with advanced mobility, has a large, perfectly sized, 7.0\" screen that offers plenty of room for the thousands of interactive games and apps available for the Android\u2122 platform, and its slim design makes it perfect for travel and one-handed grip. Use the Galaxy Tab to relax and enjoy an e-book, watch rich video or full web content with its Adobe\u00ae Flash\u00ae Player compatibility, video chat using the front-facing camera, or send user-generated content wirelessly to other devices like your TV via AllShare\u2122.  With so many options for customization and interactivity, the Galaxy Tab gives you everything you want, anywhere you go\u2026Feel Free to Tab\u2122."},
                new Phone {Name = "MOTOROLA ATRIX\u2122 4G", Age = 3,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 1313, TalkTime=5, Capacity = 21452},
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    AdditionalFeatures = "AdditionalFeatures 4",
                    Snippet ="MOTOROLA ATRIX 4G the world's most powerful smartphone.", Description = "MOTOROLA ATRIX 4G gives you dual-core processing power and the revolutionary webtop application. With webtop and a compatible Motorola docking station, sold separately, you can surf the Internet with a full Firefox browser, create and edit docs, or access multimedia on a large screen almost anywhere."},
                new Phone {Name = "MOTOROLA XOOM\u2122", Age = 2,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 2632, TalkTime=5, Capacity = 2145},
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    AdditionalFeatures = "AdditionalFeatures 5",
                    Snippet ="The Next, Next Generation\n\nExperience the future with MOTOROLA XOOM, the world's first tablet powered by Android 3.0 (Honeycomb).", Description = "MOTOROLA XOOM has a super-powerful dual-core processor and Android\u2122 3.0 (Honeycomb) \u2014 the Android platform designed specifically for tablets. With its 10.1-inch HD widescreen display, you\u2019ll enjoy HD video in a thin, light, powerful and upgradeable tablet."}
            };
            phones.ForEach(p => context.Phones.AddOrUpdate(s => s.Name, p));
            context.SaveChanges();

            var images = new List<Image>
            {
                new Image {ImageUrl = "lg-axis.0.jpg"},
                new Image {ImageUrl = "lg-axis.1.jpg"},
                new Image {ImageUrl = "lg-axis.2.jpg"},

                new Image {ImageUrl = "nexus-s.0.jpg"},
                new Image {ImageUrl = "nexus-s.1.jpg"},
                new Image {ImageUrl = "nexus-s.2.jpg"},
                new Image {ImageUrl = "nexus-s.3.jpg"},

                new Image {ImageUrl = "samsung-galaxy-tab.0.jpg"},
                new Image {ImageUrl = "samsung-galaxy-tab.1.jpg"},
                new Image {ImageUrl = "samsung-galaxy-tab.2.jpg"},
                new Image {ImageUrl = "samsung-galaxy-tab.3.jpg"},
                new Image {ImageUrl = "samsung-galaxy-tab.4.jpg"},
                new Image {ImageUrl = "samsung-galaxy-tab.5.jpg"},
                new Image {ImageUrl = "samsung-galaxy-tab.6.jpg"},

                new Image {ImageUrl = "motorola-atrix-4g.0.jpg"},
                new Image {ImageUrl = "motorola-atrix-4g.1.jpg"},
                new Image {ImageUrl = "motorola-atrix-4g.2.jpg"},
                new Image {ImageUrl = "motorola-atrix-4g.3.jpg"},

                new Image {ImageUrl = "motorola-xoom.0.jpg"},
                new Image {ImageUrl = "motorola-xoom.1.jpg"},
                new Image {ImageUrl = "motorola-xoom.2.jpg"}
            };
            images.ForEach(i => context.Images.AddOrUpdate(s => s.ImageUrl, i));
            context.SaveChanges();

            AddOrUpdatePhoneImage(context, "LG-Axis", 1);
            AddOrUpdatePhoneImage(context, "LG-Axis", 2);
            AddOrUpdatePhoneImage(context, "LG-Axis", 3);

            AddOrUpdatePhoneImage(context, "Nexus S", 4);
            AddOrUpdatePhoneImage(context, "Nexus S", 5);
            AddOrUpdatePhoneImage(context, "Nexus S", 6);
            AddOrUpdatePhoneImage(context, "Nexus S", 7);

            AddOrUpdatePhoneImage(context, "Samsung Galaxy Tab\u2122", 8);
            AddOrUpdatePhoneImage(context, "Samsung Galaxy Tab\u2122", 9);
            AddOrUpdatePhoneImage(context, "Samsung Galaxy Tab\u2122", 10);
            AddOrUpdatePhoneImage(context, "Samsung Galaxy Tab\u2122", 11);
            AddOrUpdatePhoneImage(context, "Samsung Galaxy Tab\u2122", 12);
            AddOrUpdatePhoneImage(context, "Samsung Galaxy Tab\u2122", 13);
            AddOrUpdatePhoneImage(context, "Samsung Galaxy Tab\u2122", 14);

            AddOrUpdatePhoneImage(context, "MOTOROLA ATRIX\u2122 4G", 15);
            AddOrUpdatePhoneImage(context, "MOTOROLA ATRIX\u2122 4G", 16);
            AddOrUpdatePhoneImage(context, "MOTOROLA ATRIX\u2122 4G", 17);
            AddOrUpdatePhoneImage(context, "MOTOROLA ATRIX\u2122 4G", 18);

            AddOrUpdatePhoneImage(context, "MOTOROLA XOOM\u2122", 19);
            AddOrUpdatePhoneImage(context, "MOTOROLA XOOM\u2122", 20);
            AddOrUpdatePhoneImage(context, "MOTOROLA XOOM\u2122", 21);
            context.SaveChanges();

            AddOrUpdatePhoneAndroid(context, "LG-Axis", "Android 2.1", "LG Home");
            AddOrUpdatePhoneAndroid(context, "Nexus S", "Android 2.3","Android");
            AddOrUpdatePhoneAndroid(context, "Samsung Galaxy Tab\u2122", "Android 2.1","TouchWiz");
            AddOrUpdatePhoneAndroid(context, "MOTOROLA ATRIX\u2122 4G", "Android 2.2", "MOTOBLUR");
            AddOrUpdatePhoneAndroid(context, "MOTOROLA XOOM\u2122", "Android 2.1", "MOTOBLUR");
            context.SaveChanges();

            AddOrUpdatePhoneBatteryType(context, "LG-Axis", "Li-Ion");
            AddOrUpdatePhoneBatteryType(context, "Nexus S", "Li-Ion");
            AddOrUpdatePhoneBatteryType(context, "Samsung Galaxy Tab\u2122", "Li-Pol");
            AddOrUpdatePhoneBatteryType(context, "MOTOROLA ATRIX\u2122 4G", "Li-Ion");
            AddOrUpdatePhoneBatteryType(context, "MOTOROLA XOOM\u2122", "Li-Pol");
            context.SaveChanges();

            AddOrUpdatePhoneAvailability(context, "LG-Axis", 1);
            AddOrUpdatePhoneAvailability(context, "Nexus S", 1);
            AddOrUpdatePhoneAvailability(context, "Nexus S", 2);
            AddOrUpdatePhoneAvailability(context, "Nexus S", 3);
            AddOrUpdatePhoneAvailability(context, "Nexus S", 4);
            AddOrUpdatePhoneAvailability(context, "Nexus S", 5);
            AddOrUpdatePhoneAvailability(context, "Nexus S", 6);
            AddOrUpdatePhoneAvailability(context, "Samsung Galaxy Tab\u2122", 1);
            AddOrUpdatePhoneAvailability(context, "Samsung Galaxy Tab\u2122", 5);
            AddOrUpdatePhoneAvailability(context, "Samsung Galaxy Tab\u2122", 7);
            AddOrUpdatePhoneAvailability(context, "MOTOROLA ATRIX\u2122 4G", 1);
            AddOrUpdatePhoneAvailability(context, "MOTOROLA ATRIX\u2122 4G", 9);
            AddOrUpdatePhoneAvailability(context, "MOTOROLA XOOM\u2122", 1);
            AddOrUpdatePhoneAvailability(context, "MOTOROLA XOOM\u2122", 8);
            context.SaveChanges();
        }

        void AddOrUpdatePhoneImage(PhoneCatContext context, string phoneName, int imageId)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var img = phn.Images.SingleOrDefault(i => i.Id == imageId);
            if (img == null)
                phn.Images.Add(context.Images.Single(i => i.Id == imageId));
        }
        void AddOrUpdatePhoneAndroid(PhoneCatContext context, string phoneName, string version, string ui)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var os = context.AndroidOs.SingleOrDefault(a => a.Version == version);
            phn.AndroidOs = os;
            var userI = context.AndroidUi.FirstOrDefault(u => u.Name == ui);
            phn.AndroidUi = userI;
        }

        void AddOrUpdatePhoneBatteryType(PhoneCatContext context, string phoneName, string type)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var batType = context.BatteryTypes.FirstOrDefault(b => b.Type == type);
            phn.BatteryType = batType;
        }

        void AddOrUpdatePhoneAvailability(PhoneCatContext context, string phoneName, int availability)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var av = phn.Availability.SingleOrDefault(a => a.Id == availability);
            if (av == null)
                phn.Availability.Add(context.Availabilities.Single(i => i.Id == availability));
        }
    }
}
