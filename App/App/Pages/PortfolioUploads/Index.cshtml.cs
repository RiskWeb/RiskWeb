using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using App.Helpers.Xml;
using App.Helpers.Extensions;

namespace App.Pages.PortfolioUploads
{
    public class IndexModel : PageModel
    {
        private readonly App.Models.PortfolioUploadContext _context;
        private readonly IOptions<PathSettings> _config;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IServiceProvider _serviceProvider;

        public IndexModel(App.Models.PortfolioUploadContext context,
                          IOptions<PathSettings> config,
                          IHostingEnvironment hostingEnvironment,
                          IServiceProvider serviceProvider)
        {
            _context = context;
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _serviceProvider = serviceProvider;
        }

        public IList<PortfolioUpload> PortfolioUpload { get;set; }

        public async Task OnGetAsync()
        {
            syncUploadedPortfolios();
            PortfolioUpload = await _context.PortfolioUpload.ToListAsync();
        }

        private void syncUploadedPortfolios()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@Path.Combine(_hostingEnvironment.WebRootPath, _config.Value.PortfolioUploadPath));
            FileInfo[] files = directoryInfo.GetFiles("*.xml");

            using (var context = new PortfolioUploadContext(_serviceProvider.GetRequiredService<DbContextOptions<PortfolioUploadContext>>()))
            {
                // Clear out existing portfolios
                var itemsToDelete = context.Set<PortfolioUpload>();
                context.PortfolioUpload.RemoveRange(itemsToDelete);

                //Populate db
                foreach (var file in files)
                {
                    //fileter out non-portfolios
                    using (var streamReader = new StreamReader(file.FullName))
                    {
                        dynamic portfolio = DynamicXml.Parse(streamReader.ReadToEnd());

                        try
                        {
                            context.PortfolioUpload.AddRange(
                            new PortfolioUpload
                            {
                                Name = file.Name,
                                TradeCount = portfolio.Trade.Count,
                                Agreements = "N",
                                UploadTime = file.LastWriteTime,
                                FileName = file.Name,
                                LastRunTime = file.LastAccessTime
                            });
                        }
                        catch
                        {

                        }

                    }
                }
                context.SaveChanges();
            }
        }
    }
}
