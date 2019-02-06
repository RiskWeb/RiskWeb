using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using App.Helpers.Xml;
using System.Dynamic;
using System.Xml.Linq;

namespace App.Controllers
{
    public class PortfolioUploadsController : Controller
    {
        private readonly PortfolioUploadContext _context;    
        private readonly IOptions<PathSettings> _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PortfolioUploadsController(PortfolioUploadContext context,
                                          IOptions<PathSettings> config,
                                          IServiceProvider serviceProvider, 
                                          IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _config = config;
            _serviceProvider = serviceProvider;
            _hostingEnvironment = hostingEnvironment;
        }


        //[HttpGet]
        public IActionResult UploadPortfolio()
        {
            // Run function to read folder content and upload to DB
            return View();
        }

        public async Task<IActionResult> ViewXmlPortfolio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioUpload = await _context.PortfolioUpload.FindAsync(id);
            if (portfolioUpload == null)
            {
                return NotFound();
            }
            else
            {
                //Make nicer storing full path?
                DirectoryInfo directoryInfo = new DirectoryInfo(@Path.Combine(_hostingEnvironment.WebRootPath, _config.Value.PortfolioUploadPath));
                FileInfo file = directoryInfo.GetFiles(portfolioUpload.FileName).FirstOrDefault();
                               
                using (var streamReader = new StreamReader(file.FullName))
                {
                    //read from file
                    var xDoc = XDocument.Load(streamReader);
                    dynamic root = new ExpandoObject();

                    XmlToDynamic.Parse(root, xDoc.Elements().First());

                    try
                    {
                        return View(root);
                    }
                    catch
                    {
                        return NotFound();
                    }

                }
            }

        }
        
    }
}
