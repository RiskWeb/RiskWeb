using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace App.Pages.PortfolioUploads
{
    public class DeleteModel : PageModel
    {
        private readonly App.Models.PortfolioUploadContext _context;
        private readonly IOptions<PathSettings> _config;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DeleteModel(App.Models.PortfolioUploadContext context,
                           IOptions<PathSettings> config,
                           IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _config = config;
            _hostingEnvironment = hostingEnvironment;
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PortfolioUpload = await _context.PortfolioUpload.FindAsync(id);

            if (PortfolioUpload != null)
            {
                //move to trash can 
                moveFileToTrashCanFolder(PortfolioUpload.FileName, DateTime.Now.ToString("[ddMMMyyyy_hhmmss]"));

                _context.PortfolioUpload.Remove(PortfolioUpload);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        //Moves file to "trash can" folder
        private void moveFileToTrashCanFolder(string fileName, string fileNameExtension = "")
        {
            var sourceFile = Path.Combine(_hostingEnvironment.WebRootPath, _config.Value.PortfolioUploadPath, fileName);
            var destinationFile = Path.Combine(_hostingEnvironment.WebRootPath, _config.Value.PortfolioDeletePath, fileName.Split('.')[0] + fileNameExtension +"." + fileName.Split('.')[1]);
            System.IO.File.Move(sourceFile, destinationFile);
        }
    }
}
