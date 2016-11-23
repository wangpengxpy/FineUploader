using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace FineUploader.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProcessUpload(HttpPostedFileWrapper qqfile)
        {
            string extension = qqfile.ContentType.Split('/')[1];
            if ((extension == "jpeg") || (extension == "jpg") || (extension == "gif") || (extension == "png"))
            {
                using (var inputstream = Request.InputStream)
                {
                    using (var filestream = new FileStream(@"d:\temp\" + qqfile.FileName, FileMode.Create))
                    {
                        inputstream.CopyTo(filestream);
                    }
                }
                return Json(new { success = true });

            }
            else {
                return Json(new { success = false, message = qqfile.FileName + "has an invalid extension. Valid extension(s): jpeg, jpg, gif, png." });
            }

           
        }
    }
}
