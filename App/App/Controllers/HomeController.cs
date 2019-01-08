using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using App.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload() //IList<IFormFile> files
        {
            var files = HttpContext.Request.Form.Files;
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads//portfolios");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        //TODO: read folder to register with DB context
                    }
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
