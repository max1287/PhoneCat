﻿using PhoneCat.DAL;
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
                    Os = p.AndroidOs.Version,
                    Ui = p.AndroidUi.Name
                },
                Battery = new BatteryDTO()
                {
                    StandbyTime = p.Battery.StandbyTime,
                    TalkTime = p.Battery.TalkTime,
                    Capacity = p.Battery.Capacity,
                    Type = p.BatteryType.Type,
                    TypeName = p.BatteryType.BatteryTypeName
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
            //battery{
            phone.Battery.StandbyTime = phoneDetailDTO.Battery.StandbyTime;
            phone.Battery.TalkTime = phoneDetailDTO.Battery.TalkTime;
            phone.Battery.Capacity = phoneDetailDTO.Battery.Capacity;
            var batType = db.BatteryTypes.SingleOrDefault(b => b.Type == phoneDetailDTO.Battery.Type);
            if (batType == null)
                phone.BatteryType = new BatteryType { Type = phoneDetailDTO.Battery.Type , BatteryTypeName = phoneDetailDTO.Battery.TypeName};
            else phone.BatteryType = batType;
            //}
            //image{
            List<Image> imgList = phone.Images.ToList();
            for(int i=0; i<phoneDetailDTO.Images.Count; i++)
            {
                String s = phoneDetailDTO.Images.ElementAt(i);
                Image img = await db.Images.SingleOrDefaultAsync(pic => pic.ImageUrl == s);
                if (imgList.Contains(img)==false) imgList.Add(img);
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
            //battery{
            phone.Battery = new Battery
            {
                StandbyTime = phoneDetailDTO.Battery.StandbyTime,
                TalkTime = phoneDetailDTO.Battery.TalkTime,
                Capacity = phoneDetailDTO.Battery.Capacity
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
