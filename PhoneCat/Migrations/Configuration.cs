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
            var phones = new List<Phone>
            {
                new Phone {Name = "LG-Axis", Age = 1,
                    Images = new List<Image>(),
                    Snippet ="Android Powered, Google Maps Navigation, 5 Customizable Home Screens", Description = "Android plus QWERTY is a powerful duo. LG Axis melds a speedy UI with the limitless micro-entertainment of 80,000+ apps including voice-activated Google. Feel the tactile vibration on its tempered glass touchscreen. Take the fuzziness out of your fun with a 3.2MP camera that does 360\u00b0 panoramics. And customize your home screens with shortcuts to your apps, favorites, and widgets. It's the centerpiece of your life."},
                new Phone {Name = "Nexus S", Age = 3,
                    Images = new List<Image>(),
                    Snippet ="Fast just got faster with Nexus S. A pure Google experience, Nexus S is the first phone to run Gingerbread (Android 2.3), the fastest version of Android yet.", Description = "Nexus S is the next generation of Nexus devices, co-developed by Google and Samsung. The latest Android platform (Gingerbread), paired with a 1 GHz Hummingbird processor and 16GB of memory, makes Nexus S one of the fastest phones on the market. It comes pre-installed with the best of Google apps and enabled with new and popular features like true multi-tasking, Wi-Fi hotspot, Internet Calling, NFC support, and full web browsing. With this device, users will also be the first to receive software upgrades and new Google mobile apps as soon as they become available. For more details, visit http://www.google.com/nexus"},
                new Phone {Name = "Samsung Galaxy Tab\u2122", Age = 4,
                    Images = new List<Image>(),
                    Snippet ="Feel Free to Tab\u2122. The Samsung Galaxy Tab\u2122 brings you an ultra-mobile entertainment experience through its 7\u201d display, high-power processor and Adobe\u00ae Flash\u00ae Player compatibility", Description = "Feel Free to Tab\u2122. The Samsung Galaxy Tab\u2122, the tablet device that delivers enhanced capabilities with advanced mobility, has a large, perfectly sized, 7.0\" screen that offers plenty of room for the thousands of interactive games and apps available for the Android\u2122 platform, and its slim design makes it perfect for travel and one-handed grip. Use the Galaxy Tab to relax and enjoy an e-book, watch rich video or full web content with its Adobe\u00ae Flash\u00ae Player compatibility, video chat using the front-facing camera, or send user-generated content wirelessly to other devices like your TV via AllShare\u2122.  With so many options for customization and interactivity, the Galaxy Tab gives you everything you want, anywhere you go\u2026Feel Free to Tab\u2122."},
                new Phone {Name = "MOTOROLA ATRIX\u2122 4G", Age = 3,
                    Images = new List<Image>(),
                    Snippet ="MOTOROLA ATRIX 4G the world's most powerful smartphone.", Description = "MOTOROLA ATRIX 4G gives you dual-core processing power and the revolutionary webtop application. With webtop and a compatible Motorola docking station, sold separately, you can surf the Internet with a full Firefox browser, create and edit docs, or access multimedia on a large screen almost anywhere."},
                new Phone {Name = "MOTOROLA XOOM\u2122", Age = 2,
                    Images = new List<Image>(),
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
                new Image {ImageUrl = "motorola-xoom.2.jpg"},
                new Image {ImageUrl = "motorola-xoom.3.jpg"},
                new Image {ImageUrl = "motorola-xoom.4.jpg"},
                new Image {ImageUrl = "motorola-xoom.5.jpg"}
            };
            images.ForEach(i => context.Images.AddOrUpdate(s => s.ImageUrl, i));
            context.SaveChanges();

            AddOrUpdatePhone(context, "LG-Axis", 13);
            AddOrUpdatePhone(context, "LG-Axis", 14);
            AddOrUpdatePhone(context, "LG-Axis", 15);

            AddOrUpdatePhone(context, "Nexus S", 16);
            AddOrUpdatePhone(context, "Nexus S", 17);
            AddOrUpdatePhone(context, "Nexus S", 18);
            AddOrUpdatePhone(context, "Nexus S", 19);

            AddOrUpdatePhone(context, "Samsung Galaxy Tab\u2122", 20);
            AddOrUpdatePhone(context, "Samsung Galaxy Tab\u2122", 21);
            AddOrUpdatePhone(context, "Samsung Galaxy Tab\u2122", 22);
            AddOrUpdatePhone(context, "Samsung Galaxy Tab\u2122", 23);
            AddOrUpdatePhone(context, "Samsung Galaxy Tab\u2122", 24);
            AddOrUpdatePhone(context, "Samsung Galaxy Tab\u2122", 25);
            AddOrUpdatePhone(context, "Samsung Galaxy Tab\u2122", 26);

            AddOrUpdatePhone(context, "MOTOROLA ATRIX\u2122 4G", 27);
            AddOrUpdatePhone(context, "MOTOROLA ATRIX\u2122 4G", 28);
            AddOrUpdatePhone(context, "MOTOROLA ATRIX\u2122 4G", 29);
            AddOrUpdatePhone(context, "MOTOROLA ATRIX\u2122 4G", 30);

            AddOrUpdatePhone(context, "MOTOROLA XOOM\u2122", 31);
            AddOrUpdatePhone(context, "MOTOROLA XOOM\u2122", 32);
            AddOrUpdatePhone(context, "MOTOROLA XOOM\u2122", 33);
            AddOrUpdatePhone(context, "MOTOROLA XOOM\u2122", 34);
            AddOrUpdatePhone(context, "MOTOROLA XOOM\u2122", 35);
            AddOrUpdatePhone(context, "MOTOROLA XOOM\u2122", 36);
            context.SaveChanges();

        }

        void AddOrUpdatePhone(PhoneCatContext context, string phoneName, int imageId)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var img = phn.Images.SingleOrDefault(i => i.Id == imageId);
            if (img == null)
                phn.Images.Add(context.Images.Single(i => i.Id == imageId));
        }
    }
}
