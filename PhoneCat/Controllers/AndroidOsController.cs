using PhoneCat.DAL;
using PhoneCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneCat.Controllers
{
    public class AndroidOsController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();
        public IQueryable<string> GetAndroidOs()
        {
            var androidOs = from p in db.AndroidOs
                         select (p.Version);
            return androidOs;
        }
    }
}
