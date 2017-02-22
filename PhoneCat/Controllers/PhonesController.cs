using PhoneCat.DAL;
using PhoneCat.DTO;
using PhoneCat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace PhoneCat.Controllers
{
    public class PhonesController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();

        //GET: api/phones
        public IQueryable<PhoneDTO> GetPhones()
        {
            var phones = from p in db.Phones
                         select new PhoneDTO()
                         {
                             Id = p.Id,
                             Name = p.Name,
                             Age = p.Age,
                             Snippet = p.Snippet,
                             ImageUrl = p.Images.FirstOrDefault().ImageUrl
                         };
            return phones;
        }

        // GET: api/phones/5
        [ResponseType(typeof(PhoneDetailDTO))]
        public async Task<IHttpActionResult> GetPhones(int id)
        {
            var phone = await db.Phones.Select(p =>
            new PhoneDetailDTO()
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Description = p.Description,
                Snippet = p.Snippet,
                AdditionalFeatures = p.AdditionalFeatures,
                Age = p.Age.ToString(),
                Images = p.Images.Select(g => g.ImageUrl).ToList(),
                Storage = new StorageDTO()
                {
                    Flash = p.Storage.Flash.ToString(),
                    Ram = p.Storage.Ram.ToString()
                },
                SizeAndWeight = new SizeAndWeightDTO()
                {
                    Height = p.SizeAndWeight.Height.ToString(),
                    Width = p.SizeAndWeight.Width.ToString(),
                    Depth = p.SizeAndWeight.Depth.ToString(),
                    Weight = p.SizeAndWeight.Weight.ToString()
                },
                Android = new AndroidDTO()
                {
                    Os = p.AndroidOs.Version,
                    Ui = p.AndroidUi.Name
                },
                Battery = new BatteryDTO()
                {
                    StandbyTime = p.Battery.StandbyTime.ToString(),
                    TalkTime = p.Battery.TalkTime.ToString(),
                    Capacity = p.Battery.Capacity.ToString(),
                    Type = p.BatteryType.Type,
                    TypeName = p.BatteryType.BatteryTypeName
                },
                Availability = p.Availability.Select(a => a.Name).ToList(),
                Display = new DisplayDTO()
                {
                    ScreenSize = p.Display.ScreenSize.ToString(),
                    TouchScreen = p.Display.TouchScreen,
                    Resolution = p.DisplayResolution.Height.ToString() + "x" +  p.DisplayResolution.Width.ToString(),
                    Name = p.DisplayResolution.Name
                },
                Camera = new CameraDTO()
                {
                    Primary = p.Camera.Primary.ToString()
                },
                CameraFeatures = p.CameraFeatures.Select(f => f.Name).ToList(),
                Connectivity = new ConnectivityDTO()
                {
                    Gps = p.Connectivity.Gps,
                    Infrared = p.Connectivity.Infrared,
                    Cell = p.Connectivity.Cell,
                    Bluetooth = p.Bluetooth.Version,
                    Wifi = p.Wifi.Select(w => w.Name).ToList()
                },
                Hardware = new HardwareDTO()
                {
                    Accelerometer = p.Hardware.Accelerometer,
                    AudioJack = p.Hardware.AudioJack.ToString(),
                    FmRadio = p.Hardware.FmRadio,
                    PhysicalKeyboard = p.Hardware.PhysicalKeyboard,
                    Processor = p.Processor.Name,
                    Usb = p.Usb.Version
                }
            }).SingleOrDefaultAsync(p => p.Id == id.ToString());
            

            if (phone == null)
            {
                return NotFound();
            }

            return Ok(phone);
        }

        // PUT: api/phones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhone(int id, PhoneDetailDTO phoneDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id.ToString() != phoneDetailDTO.Id)
            {
                return BadRequest();
            }

            Phone phone = await db.Phones.SingleOrDefaultAsync(p => p.Id == id);
            phone.Name = phoneDetailDTO.Name;
            phone.Snippet = phoneDetailDTO.Snippet;
            phone.Description = phoneDetailDTO.Description;
            phone.Age = Convert.ToInt32(phoneDetailDTO.Age);
            phone.Storage.Flash = Convert.ToInt32(phoneDetailDTO.Storage.Flash);
            phone.Storage.Ram = Convert.ToInt32(phoneDetailDTO.Storage.Ram);
            phone.SizeAndWeight.Height = Convert.ToDouble(phoneDetailDTO.SizeAndWeight.Height, CultureInfo.InvariantCulture);
            phone.SizeAndWeight.Width = Convert.ToDouble(phoneDetailDTO.SizeAndWeight.Width, CultureInfo.InvariantCulture);
            phone.SizeAndWeight.Depth = Convert.ToDouble(phoneDetailDTO.SizeAndWeight.Depth, CultureInfo.InvariantCulture);
            phone.SizeAndWeight.Weight = Convert.ToDouble(phoneDetailDTO.SizeAndWeight.Weight, CultureInfo.InvariantCulture);
            phone.AdditionalFeatures = phoneDetailDTO.AdditionalFeatures;
            //battery{
            phone.Battery.StandbyTime = Convert.ToInt32(phoneDetailDTO.Battery.StandbyTime);
            phone.Battery.TalkTime = Convert.ToInt32(phoneDetailDTO.Battery.TalkTime);
            phone.Battery.Capacity = Convert.ToInt32(phoneDetailDTO.Battery.Capacity);
            var batType = db.BatteryTypes.SingleOrDefault(b => b.Type == phoneDetailDTO.Battery.Type);
            if (batType == null)
                phone.BatteryType = new BatteryType { Type = phoneDetailDTO.Battery.Type, BatteryTypeName = phoneDetailDTO.Battery.TypeName };
            else phone.BatteryType = batType;
            //}

            //image{
            List<Image> imgList = phone.Images.ToList();
            for (int i = 0; i < phoneDetailDTO.Images.Count; i++)
            {
                String s = phoneDetailDTO.Images.ElementAt(i);
                Image img = await db.Images.SingleOrDefaultAsync(pic => pic.ImageUrl == s);
                if (imgList.Contains(img) == false) imgList.Add(img);
            }
            for (int i = 0; i < imgList.Count; i++)
            {
                if (phoneDetailDTO.Images.IndexOf(imgList[i].ImageUrl) < 0)
                {
                    string root = HttpContext.Current.Server.MapPath("~/Content/img/");
                    File.Delete(root + imgList[i].ImageUrl);
                    String s = imgList[i].ImageUrl;
                    Image img = await db.Images.SingleOrDefaultAsync(pic => pic.ImageUrl == s);
                    if (img != null)
                    {
                        db.Images.Remove(img);
                    }
                    imgList.Remove(imgList[i]);
                    i--;
                }
            }
            phone.Images = imgList;
            //}

            //android{
            var os = db.AndroidOs.SingleOrDefault(a => a.Version == phoneDetailDTO.Android.Os);
            if (os == null)
                phone.AndroidOs = new AndroidOs { Version = phoneDetailDTO.Android.Os };
            else phone.AndroidOs = os;
            var userI = db.AndroidUi.FirstOrDefault(u => u.Name == phoneDetailDTO.Android.Ui);
            if (userI == null)
                phone.AndroidUi = new AndroidUi { Name = phoneDetailDTO.Android.Ui };
            else phone.AndroidUi = userI;
            //}

            //availability{
            List<Availability> availabilityList = phone.Availability.ToList();
            for (int i = 0; i < phoneDetailDTO.Availability.Count; i++)
            {
                String s = phoneDetailDTO.Availability.ElementAt(i);
                Availability availability = await db.Availabilities.SingleOrDefaultAsync(av => av.Name == s);
                if (availabilityList.Contains(availability) == false) availabilityList.Add(availability);
            }
            for (int i = 0; i < availabilityList.Count; i++)
            {
                if (phoneDetailDTO.Availability.IndexOf(availabilityList[i].Name) < 0)
                {
                    availabilityList.Remove(availabilityList[i]);
                    i--;
                }
            }
            phone.Availability = availabilityList;
            //}

            //display{
            phone.Display.ScreenSize = Convert.ToDouble(phoneDetailDTO.Display.ScreenSize, CultureInfo.InvariantCulture);
            phone.Display.TouchScreen = phoneDetailDTO.Display.TouchScreen;
            var res = phoneDetailDTO.Display.Resolution.Split('x');
            int width=0, height=0;
            if (res.Count() == 2)
            {
                height = Convert.ToInt32(res[0]);
                width = Convert.ToInt32(res[1]);
            }

            var dispRes = db.DisplayResolutions.SingleOrDefault(b => b.Width == width && b.Height == height);
            if (dispRes == null)
                phone.DisplayResolution = new DisplayResolution {Height = height, Width = width};
            else phone.DisplayResolution = dispRes;
            //}

            //camera{
            phone.Camera.Primary = Convert.ToDouble(phoneDetailDTO.Camera.Primary, CultureInfo.InvariantCulture);
            List<CameraFeatures> featuresList = phone.CameraFeatures.ToList();
            for (int i = 0; i < phoneDetailDTO.CameraFeatures.Count; i++)
            {
                String s = phoneDetailDTO.CameraFeatures.ElementAt(i);
                CameraFeatures feature = await db.CameraFeatures.SingleOrDefaultAsync(f => f.Name == s);
                if (featuresList.Contains(feature) == false) featuresList.Add(feature);
            }
            for (int i = 0; i < featuresList.Count; i++)
            {
                if (phoneDetailDTO.CameraFeatures.IndexOf(featuresList[i].Name) < 0)
                {
                    featuresList.Remove(featuresList[i]);
                    i--;
                }
            }
            phone.CameraFeatures = featuresList;
            //}

            //connectivity{
            phone.Connectivity.Gps = phoneDetailDTO.Connectivity.Gps;
            phone.Connectivity.Infrared = phoneDetailDTO.Connectivity.Infrared;
            phone.Connectivity.Cell = phoneDetailDTO.Connectivity.Cell;
            var bluetooth = db.Blueteeth.SingleOrDefault(b => b.Version == phoneDetailDTO.Connectivity.Bluetooth);
            if (bluetooth == null)
                phone.Bluetooth = new Bluetooth { Version = phoneDetailDTO.Connectivity.Bluetooth };
            else phone.Bluetooth = bluetooth;

            List<Wifi> wifiList = phone.Wifi.ToList();
            for (int i = 0; i < phoneDetailDTO.Connectivity.Wifi.Count; i++)
            {
                String s = phoneDetailDTO.Connectivity.Wifi.ElementAt(i);
                Wifi wifi = await db.Wifis.SingleOrDefaultAsync(w => w.Name == s);
                if (wifiList.Contains(wifi) == false) wifiList.Add(wifi);
            }
            for (int i = 0; i < wifiList.Count; i++)
            {
                if (phoneDetailDTO.Connectivity.Wifi.IndexOf(wifiList[i].Name) < 0)
                {
                    wifiList.Remove(wifiList[i]);
                    i--;
                }
            }
            phone.Wifi = wifiList;
            //}

            //hardware{
            phone.Hardware.Accelerometer = phoneDetailDTO.Hardware.Accelerometer;
            phone.Hardware.AudioJack = Convert.ToDouble(phoneDetailDTO.Hardware.AudioJack, CultureInfo.InvariantCulture);
            phone.Hardware.FmRadio = phoneDetailDTO.Hardware.FmRadio;
            phone.Hardware.PhysicalKeyboard = phoneDetailDTO.Hardware.PhysicalKeyboard;
            var cpu = db.Processors.SingleOrDefault(c => c.Name == phoneDetailDTO.Hardware.Processor);
            if (cpu == null)
                phone.Processor = new Processor { Name = phoneDetailDTO.Hardware.Processor };
            else phone.Processor = cpu;
            var usb = db.Usb.FirstOrDefault(u => u.Version == phoneDetailDTO.Hardware.Usb);
            if (usb == null)
                phone.Usb = new Usb { Version = phoneDetailDTO.Hardware.Usb };
            else phone.Usb = usb;
            //}

            db.Entry(phone).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/phones
        [ResponseType(typeof(Phone))]
        public async Task<IHttpActionResult> PostPhone(PhoneDetailDTO phoneDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Phone phone = new Phone
            {
                Name = phoneDetailDTO.Name,
                Snippet = phoneDetailDTO.Snippet,
                Age = Convert.ToInt32(phoneDetailDTO.Age),
                Description = phoneDetailDTO.Description,
                AdditionalFeatures = phoneDetailDTO.AdditionalFeatures
            };

            //storage{
            phone.Storage = new Storage
            {
                Flash = Convert.ToInt32(phoneDetailDTO.Storage.Flash),
                Ram = Convert.ToInt32(phoneDetailDTO.Storage.Ram),
            };
            //}

            //sizeandweight{
            phone.SizeAndWeight = new SizeAndWeight
            {
                Height = Convert.ToDouble(phoneDetailDTO.SizeAndWeight.Height, CultureInfo.InvariantCulture),
                Width = Convert.ToDouble(phoneDetailDTO.SizeAndWeight.Width, CultureInfo.InvariantCulture),
                Depth = Convert.ToDouble(phoneDetailDTO.SizeAndWeight.Depth, CultureInfo.InvariantCulture),
                Weight = Convert.ToDouble(phoneDetailDTO.SizeAndWeight.Weight, CultureInfo.InvariantCulture)
            };
            //}

            //battery{
            phone.Battery = new Battery
            {
                StandbyTime = Convert.ToInt32(phoneDetailDTO.Battery.StandbyTime),
                TalkTime = Convert.ToInt32(phoneDetailDTO.Battery.TalkTime),
                Capacity = Convert.ToInt32(phoneDetailDTO.Battery.Capacity)
            };
            var batType = db.BatteryTypes.SingleOrDefault(b => b.Type == phoneDetailDTO.Battery.Type);
            if (batType == null)
                phone.BatteryType = new BatteryType { Type = phoneDetailDTO.Battery.Type, BatteryTypeName = phoneDetailDTO.Battery.TypeName };
            else phone.BatteryType = batType;
            //}
            //image{
            List<Image> imgList = new List<Image>();
            for (int i = 0; i < phoneDetailDTO.Images.Count; i++)
            {
                String s = phoneDetailDTO.Images.ElementAt(i);
                Image img = db.Images.SingleOrDefault(pic => pic.ImageUrl == s);
                imgList.Add(img);
            }
            phone.Images = imgList;
            //}
            //android{
            var os = db.AndroidOs.SingleOrDefault(a => a.Version == phoneDetailDTO.Android.Os);
            if (os == null)
                phone.AndroidOs = new AndroidOs { Version = phoneDetailDTO.Android.Os };
            else phone.AndroidOs = os;
            var userI = db.AndroidUi.FirstOrDefault(u => u.Name == phoneDetailDTO.Android.Ui);
            if (userI == null)
                phone.AndroidUi = new AndroidUi { Name = phoneDetailDTO.Android.Ui };
            else phone.AndroidUi = userI;
            //}
            //availability{
            List<Availability> availabilityList = new List<Availability>();
            for (int i = 0; i < phoneDetailDTO.Availability.Count; i++)
            {
                String s = phoneDetailDTO.Availability.ElementAt(i);
                Availability availability = await db.Availabilities.SingleOrDefaultAsync(av => av.Name == s);
                availabilityList.Add(availability);
            }
            phone.Availability = availabilityList;
            //}

            //display{
            phone.Display = new Display
            {
                ScreenSize = Convert.ToDouble(phoneDetailDTO.Display.ScreenSize, CultureInfo.InvariantCulture),
                TouchScreen = phoneDetailDTO.Display.TouchScreen
            };
            var res = phoneDetailDTO.Display.Resolution.Split('x');
            int width = 0, height = 0;
            if (res.Count() == 2)
            {
                height = Convert.ToInt32(res[0]);
                width = Convert.ToInt32(res[1]);
            }
            var dispRes = db.DisplayResolutions.SingleOrDefault(b => b.Width == width && b.Height == height);
            if (dispRes == null)
                phone.DisplayResolution = new DisplayResolution { Height = height, Width = width };
            else phone.DisplayResolution = dispRes;
            //}

            //camera{
            phone.Camera = new Camera
            {
                Primary = Convert.ToDouble(phoneDetailDTO.Camera.Primary, CultureInfo.InvariantCulture)
            };               
            List<CameraFeatures> featuresList = new List<CameraFeatures>();
            for (int i = 0; i < phoneDetailDTO.CameraFeatures.Count; i++)
            {
                String s = phoneDetailDTO.CameraFeatures.ElementAt(i);
                CameraFeatures feature = await db.CameraFeatures.SingleOrDefaultAsync(f => f.Name == s);
                featuresList.Add(feature);
            }
            phone.CameraFeatures = featuresList;
            //}

            //connectivity{
            phone.Connectivity = new Connectivity
            {
                Gps = phoneDetailDTO.Connectivity.Gps,
                Infrared = phoneDetailDTO.Connectivity.Infrared,
                Cell = phoneDetailDTO.Connectivity.Cell,
            };
            var bluetooth = db.Blueteeth.SingleOrDefault(b => b.Version == phoneDetailDTO.Connectivity.Bluetooth);
            if (bluetooth == null)
                phone.Bluetooth = new Bluetooth { Version = phoneDetailDTO.Connectivity.Bluetooth };
            else phone.Bluetooth = bluetooth;

            List<Wifi> wifiList = new List<Wifi>();
            for (int i = 0; i < phoneDetailDTO.Connectivity.Wifi.Count; i++)
            {
                String s = phoneDetailDTO.Connectivity.Wifi.ElementAt(i);
                Wifi wifi = await db.Wifis.SingleOrDefaultAsync(w => w.Name == s);
                wifiList.Add(wifi);
            }
            phone.Wifi = wifiList;
            //}

            //hardware{
            phone.Hardware = new Hardware()
            {
                Accelerometer = phoneDetailDTO.Hardware.Accelerometer,
                AudioJack = Convert.ToDouble(phoneDetailDTO.Hardware.AudioJack, CultureInfo.InvariantCulture),
                FmRadio = phoneDetailDTO.Hardware.FmRadio,
                PhysicalKeyboard = phoneDetailDTO.Hardware.PhysicalKeyboard
            };
            var cpu = db.Processors.SingleOrDefault(c => c.Name == phoneDetailDTO.Hardware.Processor);
            if (cpu == null)
                phone.Processor = new Processor { Name = phoneDetailDTO.Hardware.Processor };
            else phone.Processor = cpu;
            var usb = db.Usb.FirstOrDefault(u => u.Version == phoneDetailDTO.Hardware.Usb);
            if (usb == null)
                phone.Usb = new Usb { Version = phoneDetailDTO.Hardware.Usb };
            else phone.Usb = usb;
            //}

            db.Phones.Add(phone);
            await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = phone.Id }, phoneDetailDTO);
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneExists(int id)
        {
            return db.Phones.Count(e => e.Id == id) > 0;
        }
    }
}
