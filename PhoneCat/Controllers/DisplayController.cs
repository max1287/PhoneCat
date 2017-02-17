using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneCat.Controllers
{
    public class DisplayController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();
        public IQueryable<string> GetDisplay()
        {
            var displays = from p in db.DisplayResolutions
                            select (p.Height+"x"+p.Width);
            return displays;
        }
    }
}
