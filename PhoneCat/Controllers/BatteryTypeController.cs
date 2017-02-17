using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneCat.Controllers
{
    public class BatteryTypeController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();
        public IQueryable<string> GetBatteryType()
        {
            var batteryTypes = from p in db.BatteryTypes
                            select (p.Type);
            return batteryTypes;
        }
    }
}
