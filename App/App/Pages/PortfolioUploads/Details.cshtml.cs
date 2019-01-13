using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Pages.PortfolioUploads
{
    public class DetailsModel : PageModel
    {
        private readonly App.Models.PortfolioUploadContext _context;

        public DetailsModel(App.Models.PortfolioUploadContext context)
        {
            _context = context;
        }

        public PortfolioUpload PortfolioUpload { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PortfolioUpload = await _context.PortfolioUpload.FirstOrDefaultAsync(m => m.Id == id);

            if (PortfolioUpload == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
