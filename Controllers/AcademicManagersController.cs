using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using St10375622Part2.Data;
using St10375622Part2.Models;

namespace St10375622Part2.Controllers
{
    public class AcademicManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademicManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcademicManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcademicManager.ToListAsync());
        }

        // GET: AcademicManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicManager = await _context.AcademicManager
                .FirstOrDefaultAsync(m => m.AcademicManagerId == id);
            if (academicManager == null)
            {
                return NotFound();
            }

            return View(academicManager);
        }

        // GET: AcademicManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcademicManagerId,Name,email,Location")] AcademicManager academicManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicManager);
        }

        // GET: AcademicManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicManager = await _context.AcademicManager.FindAsync(id);
            if (academicManager == null)
            {
                return NotFound();
            }
            return View(academicManager);
        }

        // POST: AcademicManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcademicManagerId,Name,email,Location")] AcademicManager academicManager)
        {
            if (id != academicManager.AcademicManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicManagerExists(academicManager.AcademicManagerId))
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
            return View(academicManager);
        }

        // GET: AcademicManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicManager = await _context.AcademicManager
                .FirstOrDefaultAsync(m => m.AcademicManagerId == id);
            if (academicManager == null)
            {
                return NotFound();
            }

            return View(academicManager);
        }

        // POST: AcademicManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicManager = await _context.AcademicManager.FindAsync(id);
            if (academicManager != null)
            {
                _context.AcademicManager.Remove(academicManager);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicManagerExists(int id)
        {
            return _context.AcademicManager.Any(e => e.AcademicManagerId == id);
        }
    }
}
