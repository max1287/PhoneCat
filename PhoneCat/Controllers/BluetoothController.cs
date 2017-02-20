using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneCat.Controllers
{
    public class BluetoothController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();
        public IQueryable<string> GetBluetooth()
        {
            var bluetooth = from p in db.Blueteeth
                               select (p.Version);
            return bluetooth;
        }
    }
}
