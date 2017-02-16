using PhoneCat.DAL;
using PhoneCat.DTO;
using PhoneCat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Snippet = p.Snippet,
                AdditionalFeatures = p.AdditionalFeatures,
                Age = p.Age,
                Images = p.Images.Select(g => g.ImageUrl).ToList(),
                Storage = p.Storage,
                SizeAndWeight = p.SizeAndWeight,
                Android = new AndroidDTO()
                {
                    Os = p.Android.Os.Version,
                    Ui = p.Android.Ui
                }        
            }).SingleOrDefaultAsync(p => p.Id == id);
            

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

            if (id != phoneDetailDTO.Id)
            {
                return BadRequest();
            }

            Phone phone = await db.Phones.SingleOrDefaultAsync(p => p.Id == id);
            phone.Name = phoneDetailDTO.Name;
            phone.Snippet = phoneDetailDTO.Snippet;
            phone.Description = phoneDetailDTO.Description;
            phone.Age = phoneDetailDTO.Age;
            phone.Storage = phoneDetailDTO.Storage;
            phone.SizeAndWeight = phoneDetailDTO.SizeAndWeight;
            List<Image> imgList = phone.Images.ToList();
            for(int i=0; i<phoneDetailDTO.Images.Count; i++)
            {
                String s = phoneDetailDTO.Images.ElementAt(i);
                Image img = await db.Images.SingleOrDefaultAsync(pic => pic.ImageUrl == s);
                if (imgList.Contains(img)==false) imgList.Add(img);
            }
            phone.Images = imgList;

            var os = db.AndroidOs.SingleOrDefault(a => a.Version == phoneDetailDTO.Android.Os);
            var userI = os.Androids.FirstOrDefault(u => u.Ui == phoneDetailDTO.Android.Ui);
            if (userI == null)
                phone.Android = new Android { Os = os, Ui = phoneDetailDTO.Android.Ui };
            else phone.Android = userI;

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
                Age = phoneDetailDTO.Age,
                Description = phoneDetailDTO.Description,
                Storage = phoneDetailDTO.Storage,
                SizeAndWeight = phoneDetailDTO.SizeAndWeight,
                AdditionalFeatures = phoneDetailDTO.AdditionalFeatures                
            };
            List<Image> imgList = new List<Image>();
            for (int i = 0; i < phoneDetailDTO.Images.Count; i++)
            {
                String s = phoneDetailDTO.Images.ElementAt(i);
                Image img = db.Images.SingleOrDefault(pic => pic.ImageUrl == s);
                imgList.Add(img);
            }
            phone.Images = imgList;

            var os = db.AndroidOs.SingleOrDefault(a => a.Version == phoneDetailDTO.Android.Os);
            var userI = os.Androids.FirstOrDefault(u => u.Ui == phoneDetailDTO.Android.Ui);
            if (userI == null)
                phone.Android = new Android { Os = os, Ui = phoneDetailDTO.Android.Ui };
            else phone.Android = userI;

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
