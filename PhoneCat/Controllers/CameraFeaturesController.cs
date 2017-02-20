using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneCat.Controllers
{
    public class CameraFeaturesController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();
        public IQueryable<string> GetCameraFeatures()
        {
            var features = from p in db.CameraFeatures
                                 select (p.Name);
            return features;
        }
    }
}
