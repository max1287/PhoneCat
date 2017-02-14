using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;

namespace PhoneCat.Controllers
{
    public class ImageController : ApiController
    {
        private PhoneCatContext db = new PhoneCatContext();

        public HttpResponseMessage GetImage(string imageUrl)
        {
            if (imageUrl != null)
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                string filePath = HostingEnvironment.MapPath("~/Content/img/"+imageUrl);
                if (File.Exists(filePath))
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        Image image = Image.FromStream(fileStream);
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            image.Save(memoryStream, ImageFormat.Jpeg);
                            result.Content = new ByteArrayContent(memoryStream.ToArray());
                            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                        }
                    }
                    return result;
                }
                else return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
