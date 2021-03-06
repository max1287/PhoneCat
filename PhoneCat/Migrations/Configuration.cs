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
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 1000, TalkTime=5, Capacity = 1180},
                    Display = new Display {ScreenSize = 5.1, TouchScreen = true },
                    Camera = new Camera {Primary = 5.0 },
                    Hardware = new Hardware {Accelerometer = true, AudioJack = 3.5, FmRadio = true, PhysicalKeyboard = false },
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    Connectivity = new Connectivity {Gps = true, Infrared = false, Cell = "Quad-band GSM: 850, 900, 1800, 1900\r\nTri-band HSPA: 900, 2100, 1700\r\nHSPA type: HSDPA (7.2Mbps) HSUPA (5.76Mbps)"},
                    AdditionalFeatures = "AdditionalFeatures 1",
                    Snippet ="Android Powered, Google Maps Navigation, 5 Customizable Home Screens", Description = "Android plus QWERTY is a powerful duo. LG Axis melds a speedy UI with the limitless micro-entertainment of 80,000+ apps including voice-activated Google. Feel the tactile vibration on its tempered glass touchscreen. Take the fuzziness out of your fun with a 3.2MP camera that does 360\u00b0 panoramics. And customize your home screens with shortcuts to your apps, favorites, and widgets. It's the centerpiece of your life."},
                new Phone {Name = "Nexus S", Age = 3,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 1000, TalkTime=5, Capacity = 245},
                    Display = new Display {ScreenSize = 5.1, TouchScreen = true },
                    Camera = new Camera {Primary = 9.1 },
                    Hardware = new Hardware {Accelerometer = true, AudioJack = 3.5, FmRadio = true, PhysicalKeyboard = false },
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    Connectivity = new Connectivity {Gps = true, Infrared = false, Cell = "Quad-band GSM: 850, 900, 1800, 1900\r\nTri-band HSPA: 900, 2100, 1700\r\nHSPA type: HSDPA (7.2Mbps) HSUPA (5.76Mbps)"},
                    AdditionalFeatures = "AdditionalFeatures 2",
                    Snippet ="Fast just got faster with Nexus S. A pure Google experience, Nexus S is the first phone to run Gingerbread (Android 2.3), the fastest version of Android yet.", Description = "Nexus S is the next generation of Nexus devices, co-developed by Google and Samsung. The latest Android platform (Gingerbread), paired with a 1 GHz Hummingbird processor and 16GB of memory, makes Nexus S one of the fastest phones on the market. It comes pre-installed with the best of Google apps and enabled with new and popular features like true multi-tasking, Wi-Fi hotspot, Internet Calling, NFC support, and full web browsing. With this device, users will also be the first to receive software upgrades and new Google mobile apps as soon as they become available. For more details, visit http://www.google.com/nexus"},
                new Phone {Name = "Samsung Galaxy Tab\u2122", Age = 4,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 452, TalkTime=5, Capacity = 24521},
                    Display = new Display {ScreenSize = 5.1, TouchScreen = true },
                    Camera = new Camera {Primary = 10.0 },
                    Hardware = new Hardware {Accelerometer = true, AudioJack = 3.5, FmRadio = true, PhysicalKeyboard = false },
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    Connectivity = new Connectivity {Gps = true, Infrared = false, Cell = "Quad-band GSM: 850, 900, 1800, 1900\r\nTri-band HSPA: 900, 2100, 1700\r\nHSPA type: HSDPA (7.2Mbps) HSUPA (5.76Mbps)"},
                    AdditionalFeatures = "AdditionalFeatures 3",
                    Snippet ="Feel Free to Tab\u2122. The Samsung Galaxy Tab\u2122 brings you an ultra-mobile entertainment experience through its 7\u201d display, high-power processor and Adobe\u00ae Flash\u00ae Player compatibility", Description = "Feel Free to Tab\u2122. The Samsung Galaxy Tab\u2122, the tablet device that delivers enhanced capabilities with advanced mobility, has a large, perfectly sized, 7.0\" screen that offers plenty of room for the thousands of interactive games and apps available for the Android\u2122 platform, and its slim design makes it perfect for travel and one-handed grip. Use the Galaxy Tab to relax and enjoy an e-book, watch rich video or full web content with its Adobe\u00ae Flash\u00ae Player compatibility, video chat using the front-facing camera, or send user-generated content wirelessly to other devices like your TV via AllShare\u2122.  With so many options for customization and interactivity, the Galaxy Tab gives you everything you want, anywhere you go\u2026Feel Free to Tab\u2122."},
                new Phone {Name = "MOTOROLA ATRIX\u2122 4G", Age = 3,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 1313, TalkTime=5, Capacity = 21452},
                    Display = new Display {ScreenSize = 5.1, TouchScreen = true },
                    Camera = new Camera {Primary = 5.0 },
                    Hardware = new Hardware {Accelerometer = true, AudioJack = 3.5, FmRadio = true, PhysicalKeyboard = false },
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    Connectivity = new Connectivity {Gps = true, Infrared = false, Cell = "Quad-band GSM: 850, 900, 1800, 1900\r\nTri-band HSPA: 900, 2100, 1700\r\nHSPA type: HSDPA (7.2Mbps) HSUPA (5.76Mbps)"},
                    AdditionalFeatures = "AdditionalFeatures 4",
                    Snippet ="MOTOROLA ATRIX 4G the world's most powerful smartphone.", Description = "MOTOROLA ATRIX 4G gives you dual-core processing power and the revolutionary webtop application. With webtop and a compatible Motorola docking station, sold separately, you can surf the Internet with a full Firefox browser, create and edit docs, or access multimedia on a large screen almost anywhere."},
                new Phone {Name = "MOTOROLA XOOM\u2122", Age = 2,
                    Images = new List<Image>(),
                    Storage = new Storage {Flash = 123, Ram=313 },
                    Battery = new Battery {StandbyTime = 2632, TalkTime=5, Capacity = 2145},
                    Display = new Display {ScreenSize = 5.1, TouchScreen = true },
                    Camera = new Camera {Primary = 3.0 },
                    Hardware = new Hardware {Accelerometer = true, AudioJack = 3.5, FmRadio = true, PhysicalKeyboard = false },
                    SizeAndWeight = new SizeAndWeight {Height = 10.0, Width = 131.1, Depth = 10.12, Weight = 12.1 },
                    Connectivity = new Connectivity {Gps = true, Infrared = false, Cell = "Quad-band GSM: 850, 900, 1800, 1900\r\nTri-band HSPA: 900, 2100, 1700\r\nHSPA type: HSDPA (7.2Mbps) HSUPA (5.76Mbps)"},
                    AdditionalFeatures = "AdditionalFeatures 5",
                    Snippet ="The Next, Next Generation\n\nExperience the future with MOTOROLA XOOM, the world's first tablet powered by Android 3.0 (Honeycomb).", Description = "MOTOROLA XOOM has a super-powerful dual-core processor and Android\u2122 3.0 (Honeycomb) \u2014 the Android platform designed specifically for tablets. With its 10.1-inch HD widescreen display, you\u2019ll enjoy HD video in a thin, light, powerful and upgradeable tablet."}
            };
            phones.ForEach(p => context.Phones.AddOrUpdate(s => s.Name, p));
            context.SaveChanges();
            //}

            //images{
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
            //}

            //android{
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
            AddOrUpdatePhoneAndroid(context, "LG-Axis", "Android 2.1", "LG Home");
            AddOrUpdatePhoneAndroid(context, "Nexus S", "Android 2.3","Android");
            AddOrUpdatePhoneAndroid(context, "Samsung Galaxy Tab\u2122", "Android 2.1","TouchWiz");
            AddOrUpdatePhoneAndroid(context, "MOTOROLA ATRIX\u2122 4G", "Android 2.2", "MOTOBLUR");
            AddOrUpdatePhoneAndroid(context, "MOTOROLA XOOM\u2122", "Android 2.1", "MOTOBLUR");
            context.SaveChanges();
            //}

            //battaries{
            var batteryTypes = new List<BatteryType>
            {
            new BatteryType {Type = "Li-Ion", BatteryTypeName = "Lithium Ion" },
            new BatteryType {Type = "Li-Pol", BatteryTypeName = "Lithium Polymer" },
            new BatteryType {Type = "NiCd", BatteryTypeName = "Nickel Cadmium" }
            };
            batteryTypes.ForEach(b => context.BatteryTypes.AddOrUpdate(s => s.Type, b));
            context.SaveChanges();
            AddOrUpdatePhoneBatteryType(context, "LG-Axis", "Li-Ion");
            AddOrUpdatePhoneBatteryType(context, "Nexus S", "Li-Ion");
            AddOrUpdatePhoneBatteryType(context, "Samsung Galaxy Tab\u2122", "Li-Pol");
            AddOrUpdatePhoneBatteryType(context, "MOTOROLA ATRIX\u2122 4G", "Li-Ion");
            AddOrUpdatePhoneBatteryType(context, "MOTOROLA XOOM\u2122", "Li-Pol");
            context.SaveChanges();
            //}

            //availabilities{
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
            //}

            //display{
            var displayResolutions = new List<DisplayResolution>
            {
                new DisplayResolution {Height = 960, Width = 540, Name = "QHD"},
                new DisplayResolution {Height = 800, Width = 480, Name = "WVGA"},
                new DisplayResolution {Height = 1200, Width = 800, Name = "WXGA"}
            };
            displayResolutions.ForEach(d => context.DisplayResolutions.AddOrUpdate(s => s.Name, d));
            context.SaveChanges();
            AddOrUpdatePhoneDisplayResolution(context, "LG-Axis", "QHD");
            AddOrUpdatePhoneDisplayResolution(context, "Nexus S", "WVGA");
            AddOrUpdatePhoneDisplayResolution(context, "Samsung Galaxy Tab\u2122", "QHD");
            AddOrUpdatePhoneDisplayResolution(context, "MOTOROLA ATRIX\u2122 4G", "WVGA");
            AddOrUpdatePhoneDisplayResolution(context, "MOTOROLA XOOM\u2122", "WXGA");
            context.SaveChanges();
            //}

            //camera{
            var cameraFeatures = new List<CameraFeatures>
            {
                new CameraFeatures {Name = "Flash"},
                new CameraFeatures {Name = "Video"},
                new CameraFeatures {Name = "Param"},
                new CameraFeatures {Name = "LivePhoto"}
            };
            cameraFeatures.ForEach(c => context.CameraFeatures.AddOrUpdate(s=>s.Name,c));
            context.SaveChanges();
            AddOrUpdatePhoneCameraFeatures(context, "LG-Axis", 1);
            AddOrUpdatePhoneCameraFeatures(context, "LG-Axis", 2);
            AddOrUpdatePhoneCameraFeatures(context, "Nexus S", 1);
            AddOrUpdatePhoneCameraFeatures(context, "Nexus S", 2);
            AddOrUpdatePhoneCameraFeatures(context, "Samsung Galaxy Tab\u2122", 1);
            AddOrUpdatePhoneCameraFeatures(context, "Samsung Galaxy Tab\u2122", 2);
            AddOrUpdatePhoneCameraFeatures(context, "Samsung Galaxy Tab\u2122", 3);
            AddOrUpdatePhoneCameraFeatures(context, "MOTOROLA ATRIX\u2122 4G", 4);
            AddOrUpdatePhoneCameraFeatures(context, "MOTOROLA ATRIX\u2122 4G", 1);
            AddOrUpdatePhoneCameraFeatures(context, "MOTOROLA XOOM\u2122", 1);
            AddOrUpdatePhoneCameraFeatures(context, "MOTOROLA XOOM\u2122", 3);
            context.SaveChanges();
            //}

            //connectivity{
            var blueteeth = new List<Bluetooth>
            {
                new Bluetooth {Version = "Bluetooth 2.0"},
                new Bluetooth {Version = "Bluetooth 2.1"},
                new Bluetooth {Version = "Bluetooth 3.0"}
            };
            blueteeth.ForEach(b => context.Blueteeth.AddOrUpdate(s => s.Version, b));
            context.SaveChanges();
            AddOrUpdatePhoneBluetooth(context, "LG-Axis", 1);
            AddOrUpdatePhoneBluetooth(context, "Nexus S", 2);
            AddOrUpdatePhoneBluetooth(context, "Samsung Galaxy Tab\u2122", 2);
            AddOrUpdatePhoneBluetooth(context, "MOTOROLA ATRIX\u2122 4G", 1);
            AddOrUpdatePhoneBluetooth(context, "MOTOROLA XOOM\u2122", 3);
            context.SaveChanges();
            var wifis = new List<Wifi>
            {
                new Wifi {Name = "802.11 b"},
                new Wifi {Name = "802.11 g"},
                new Wifi {Name = "802.11 n"},
                new Wifi {Name = "802.11 a"},
                new Wifi {Name = "802.11 ac"}
            };
            wifis.ForEach(w => context.Wifis.AddOrUpdate(s => s.Name, w));
            context.SaveChanges();
            AddOrUpdatePhoneWifi(context, "LG-Axis", 1);
            AddOrUpdatePhoneWifi(context, "LG-Axis", 2);
            AddOrUpdatePhoneWifi(context, "Nexus S", 1);
            AddOrUpdatePhoneWifi(context, "Nexus S", 2);
            AddOrUpdatePhoneWifi(context, "Samsung Galaxy Tab\u2122", 1);
            AddOrUpdatePhoneWifi(context, "Samsung Galaxy Tab\u2122", 2);
            AddOrUpdatePhoneWifi(context, "Samsung Galaxy Tab\u2122", 3);
            AddOrUpdatePhoneWifi(context, "MOTOROLA ATRIX\u2122 4G", 4);
            AddOrUpdatePhoneWifi(context, "MOTOROLA ATRIX\u2122 4G", 1);
            AddOrUpdatePhoneWifi(context, "MOTOROLA XOOM\u2122", 1);
            AddOrUpdatePhoneWifi(context, "MOTOROLA XOOM\u2122", 3);
            //}

            //hardware{
            var processors = new List<Processor>
            {
                new Processor {Name = "1 GHz Dual Core" },
                new Processor {Name = "1GHz Cortex A8 (Hummingbird) processor" },
                new Processor {Name = "2nd Generation 1GHz Qualcomm Snapdragon MSM8255" },
                new Processor {Name = "1.2 GHz TI OMAP" },
                new Processor {Name = "1 GHz" }
            };
            processors.ForEach(p => context.Processors.AddOrUpdate(s => s.Name, p));
            context.SaveChanges();
            AddOrUpdatePhoneProcessor(context, "LG-Axis", 1);
            AddOrUpdatePhoneProcessor(context, "Nexus S", 2);
            AddOrUpdatePhoneProcessor(context, "Samsung Galaxy Tab\u2122", 3);
            AddOrUpdatePhoneProcessor(context, "MOTOROLA ATRIX\u2122 4G", 5);
            AddOrUpdatePhoneProcessor(context, "MOTOROLA XOOM\u2122", 4);
            context.SaveChanges();
            var usbs = new List<Usb>
            {
                new Usb {Version = "USB 1.1" },
                new Usb {Version = "USB 2.0" },
                new Usb {Version = "USB 3.0" }
            };
            usbs.ForEach(u => context.Usb.AddOrUpdate(s => s.Version, u));
            context.SaveChanges();
            AddOrUpdatePhoneUsb(context, "LG-Axis", 1);
            AddOrUpdatePhoneUsb(context, "Nexus S", 2);
            AddOrUpdatePhoneUsb(context, "Samsung Galaxy Tab\u2122", 2);
            AddOrUpdatePhoneUsb(context, "MOTOROLA ATRIX\u2122 4G", 2);
            AddOrUpdatePhoneUsb(context, "MOTOROLA XOOM\u2122", 3);
            context.SaveChanges();
            //}
        }

        void AddOrUpdatePhoneImage(PhoneCatContext context, string phoneName, int imageId)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            if (phn.Images == null) phn.Images = new List<Image>();
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
            if (phn.Availability == null) phn.Availability = new List<Availability>();
            var av = phn.Availability.SingleOrDefault(a => a.Id == availability);
            if (av == null)
                phn.Availability.Add(context.Availabilities.Single(i => i.Id == availability));
        }

        void AddOrUpdatePhoneDisplayResolution(PhoneCatContext context, string phoneName, string name)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var dispRes = context.DisplayResolutions.FirstOrDefault(d => d.Name == name);
            phn.DisplayResolution = dispRes;
        }

        void AddOrUpdatePhoneCameraFeatures(PhoneCatContext context, string phoneName, int feature)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            if (phn.CameraFeatures == null) phn.CameraFeatures = new List<CameraFeatures>();
            var feat = phn.CameraFeatures.SingleOrDefault(f => f.Id == feature);
            if (feat == null)
                phn.CameraFeatures.Add(context.CameraFeatures.Single(i => i.Id == feature));
        }

        void AddOrUpdatePhoneBluetooth(PhoneCatContext context, string phoneName, int id)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var blue = context.Blueteeth.FirstOrDefault(d => d.Id == id);
            phn.Bluetooth = blue;
        }

        void AddOrUpdatePhoneWifi(PhoneCatContext context, string phoneName, int id)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            if (phn.Wifi == null) phn.Wifi = new List<Wifi>();
            var wifi = phn.Wifi.SingleOrDefault(f => f.Id == id);
            if (wifi == null)
                phn.Wifi.Add(context.Wifis.Single(i => i.Id == id));
        }
        void AddOrUpdatePhoneProcessor(PhoneCatContext context, string phoneName, int id)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var cpu = context.Processors.FirstOrDefault(d => d.Id == id);
            phn.Processor = cpu;
        }
        void AddOrUpdatePhoneUsb(PhoneCatContext context, string phoneName, int id)
        {
            var phn = context.Phones.SingleOrDefault(p => p.Name == phoneName);
            var usb = context.Usb.FirstOrDefault(d => d.Id == id);
            phn.Usb = usb;
        }
    }
}
