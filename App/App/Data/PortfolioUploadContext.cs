using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class PortfolioUploadContext : DbContext
    {
        public PortfolioUploadContext (DbContextOptions<PortfolioUploadContext> options)
            : base(options)
        {
        }

        public DbSet<App.Models.PortfolioUpload> PortfolioUpload { get; set; }
    }
}
