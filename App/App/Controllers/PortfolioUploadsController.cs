using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using App.Helpers.Xml;
using App.Helpers.Extensions;

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
                    dynamic portfolio = DynamicXml.Parse(streamReader.ReadToEnd()).ToExpando();

                    try
                    {
                        return View(portfolio);
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
