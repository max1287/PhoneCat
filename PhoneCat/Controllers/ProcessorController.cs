using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneCat.Controllers
{
    public class ProcessorController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();
        public IQueryable<string> GetProcessor()
        {
            var cpu = from p in db.Processors
                            select (p.Name);
            return cpu;
        }
    }
}
