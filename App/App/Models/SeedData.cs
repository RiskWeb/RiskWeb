using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PortfolioUploadContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PortfolioUploadContext>>()))
            {
                // Look for any movies.
                if (context.PortfolioUpload.Any())
                {
                    return;   // DB has been seeded
                }

                context.PortfolioUpload.AddRange(
                    new PortfolioUpload
                    {
                        Name = "Example 1",
                        TradeCount = 1,
                        Agreements = "N",
                        UploadTime = DateTime.Parse("1989-2-12"),
                        FileName ="Apa.xml",
                        LastRunTime = DateTime.Parse("1989-2-12")
                    },

                    new PortfolioUpload
                    {
                        Name = "Example 2",
                        TradeCount = 1,
                        Agreements = "N",
                        UploadTime = DateTime.Parse("2019-2-12"),
                        FileName = "Apa.xml",
                        LastRunTime = DateTime.Parse("2011-2-12")
                    },

                    new PortfolioUpload
                    {
                        Name = "Example 3",
                        TradeCount = 10,
                        Agreements = "y",
                        UploadTime = DateTime.Parse("2013-2-12"),
                        FileName = "Apa.xml",
                        LastRunTime = DateTime.Parse("2012-2-12")
                    },

                    new PortfolioUpload
                    {
                        Name = "Example 4",
                        TradeCount = 50000,
                        Agreements = "N",
                        UploadTime = DateTime.Parse("2014-2-12"),
                        FileName = "Apa.xml",
                        LastRunTime = DateTime.Parse("2013-2-12")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
