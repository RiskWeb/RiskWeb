using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Pages.PortfolioUploads
{
    public class EditModel : PageModel
    {
        private readonly App.Models.PortfolioUploadContext _context;

        public EditModel(App.Models.PortfolioUploadContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PortfolioUpload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioUploadExists(PortfolioUpload.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PortfolioUploadExists(int id)
        {
            return _context.PortfolioUpload.Any(e => e.Id == id);
        }
    }
}
