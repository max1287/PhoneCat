﻿using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneCat.Controllers
{
    public class AndroidUiController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();
        public IQueryable<string> GetAndroidUi()
        {
            var androidUi = from p in db.AndroidUi
                            select (p.Name);
            return androidUi;
        }
    }
}
