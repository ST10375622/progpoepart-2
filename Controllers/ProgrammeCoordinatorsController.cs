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
    public class ProgrammeCoordinatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgrammeCoordinatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProgrammeCoordinators
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgrammeCoordinator.ToListAsync());
        }

        // GET: ProgrammeCoordinators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmeCoordinator = await _context.ProgrammeCoordinator
                .FirstOrDefaultAsync(m => m.ProgrammeCoordinatorId == id);
            if (programmeCoordinator == null)
            {
                return NotFound();
            }

            return View(programmeCoordinator);
        }

        // GET: ProgrammeCoordinators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgrammeCoordinators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgrammeCoordinatorId,Name,email,Location")] ProgrammeCoordinator programmeCoordinator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programmeCoordinator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programmeCoordinator);
        }

        // GET: ProgrammeCoordinators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmeCoordinator = await _context.ProgrammeCoordinator.FindAsync(id);
            if (programmeCoordinator == null)
            {
                return NotFound();
            }
            return View(programmeCoordinator);
        }

        // POST: ProgrammeCoordinators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgrammeCoordinatorId,Name,email,Location")] ProgrammeCoordinator programmeCoordinator)
        {
            if (id != programmeCoordinator.ProgrammeCoordinatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programmeCoordinator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammeCoordinatorExists(programmeCoordinator.ProgrammeCoordinatorId))
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
            return View(programmeCoordinator);
        }

        // GET: ProgrammeCoordinators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmeCoordinator = await _context.ProgrammeCoordinator
                .FirstOrDefaultAsync(m => m.ProgrammeCoordinatorId == id);
            if (programmeCoordinator == null)
            {
                return NotFound();
            }

            return View(programmeCoordinator);
        }

        // POST: ProgrammeCoordinators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programmeCoordinator = await _context.ProgrammeCoordinator.FindAsync(id);
            if (programmeCoordinator != null)
            {
                _context.ProgrammeCoordinator.Remove(programmeCoordinator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrammeCoordinatorExists(int id)
        {
            return _context.ProgrammeCoordinator.Any(e => e.ProgrammeCoordinatorId == id);
        }
    }
}
