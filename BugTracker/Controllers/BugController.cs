#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Models;

namespace BugTracker.Controllers
{
    public class BugController : Controller
    {
        private readonly BugDbContext _context;

        public BugController(BugDbContext context)
        {
            _context = context;
        }

        // GET: Bug
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bugs.ToListAsync());
        }


        // GET: Bug/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Bug());
            else
                return View(_context.Bugs.Find(id));
        }

        // POST: Bug/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("BugTrackId,BugName,BugDescription,Priority,DateFiled")] Bug bug)
        {
            if (ModelState.IsValid)
            {
                if (bug.BugTrackId == 0)
                {
                    bug.DateFiled = DateTime.Now;
                    _context.Add(bug);
                }
                else
                    _context.Update(bug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bug);
        }


        // POST: Bug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);
            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
