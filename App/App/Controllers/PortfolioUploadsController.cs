using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Controllers
{
    public class PortfolioUploadsController : Controller
    {
        private readonly PortfolioUploadContext _context;

        public PortfolioUploadsController(PortfolioUploadContext context)
        {
            _context = context;
        }

        // GET: PortfolioUploads
        public async Task<IActionResult> Index()
        {
            return View(await _context.PortfolioUpload.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            return View(await _context.PortfolioUpload.ToListAsync());
        }

        // GET: PortfolioUploads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioUpload = await _context.PortfolioUpload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioUpload == null)
            {
                return NotFound();
            }

            return View(portfolioUpload);
        }

        // GET: PortfolioUploads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioUploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TradeCount,Agreements,UploadTime,FileName,LastRunTime")] PortfolioUpload portfolioUpload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolioUpload);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioUpload);
        }

        // GET: PortfolioUploads/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(portfolioUpload);
        }

        // POST: PortfolioUploads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TradeCount,Agreements,UploadTime,FileName,LastRunTime")] PortfolioUpload portfolioUpload)
        {
            if (id != portfolioUpload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolioUpload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioUploadExists(portfolioUpload.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioUpload);
        }

        // GET: PortfolioUploads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioUpload = await _context.PortfolioUpload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioUpload == null)
            {
                return NotFound();
            }

            return View(portfolioUpload);
        }

        // POST: PortfolioUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolioUpload = await _context.PortfolioUpload.FindAsync(id);
            _context.PortfolioUpload.Remove(portfolioUpload);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioUploadExists(int id)
        {
            return _context.PortfolioUpload.Any(e => e.Id == id);
        }
    }
}
