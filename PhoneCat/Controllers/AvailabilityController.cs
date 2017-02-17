using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneCat.Controllers
{
    public class AvailabilityController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();
        public IQueryable<string> GetAvailability()
        {
            var availabilities = from p in db.Availabilities
                            select (p.Name);
            return availabilities;
        }
    }
}
