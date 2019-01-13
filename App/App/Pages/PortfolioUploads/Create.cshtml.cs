using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Models;

namespace App.Pages.PortfolioUploads
{
    public class CreateModel : PageModel
    {
        private readonly App.Models.PortfolioUploadContext _context;

        public CreateModel(App.Models.PortfolioUploadContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PortfolioUpload PortfolioUpload { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PortfolioUpload.Add(PortfolioUpload);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}