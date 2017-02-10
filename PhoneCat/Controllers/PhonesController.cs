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
                             Snippet = p.Snippet
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
                Age = p.Age
            }).SingleOrDefaultAsync(p => p.Id == id);

            if (phone == null)
            {
                return NotFound();
            }

            return Ok(phone);
        }

        // PUT: api/phones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhone(int id, Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phone.Id)
            {
                return BadRequest();
            }

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
        public async Task<IHttpActionResult> PostPhone(Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phones.Add(phone);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = phone.Id }, phone);
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
