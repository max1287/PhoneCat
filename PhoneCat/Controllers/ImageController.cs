using Newtonsoft.Json;
using PhoneCat.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
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
        
        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                List<string> urls = new List<string>();
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                    int startIndex = file.LocalFileName.LastIndexOf('\\')+1;
                    string fileName = file.LocalFileName.Substring(startIndex);
                    urls.Add(fileName);
                }
                urls.ForEach(u => db.Images.Add(new Models.Image { ImageUrl = u}));
                await db.SaveChangesAsync();
                HttpResponseMessage h = new HttpResponseMessage(HttpStatusCode.OK);
                h.Content = new StringContent(JsonConvert.SerializeObject(urls),
                                            System.Text.Encoding.UTF8, "application/json");
                return h;
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        
    }
}
