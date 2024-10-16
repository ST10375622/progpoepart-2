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
    public class ProjectUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectUsers.ToListAsync());
        }

        // GET: ProjectUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectUsers = await _context.ProjectUsers
                .FirstOrDefaultAsync(m => m.userId == id);
            if (projectUsers == null)
            {
                return NotFound();
            }

            return View(projectUsers);
        }

        // GET: ProjectUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userId,FirstName,LastName,Email")] ProjectUsers projectUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectUsers);
        }

        // GET: ProjectUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectUsers = await _context.ProjectUsers.FindAsync(id);
            if (projectUsers == null)
            {
                return NotFound();
            }
            return View(projectUsers);
        }

        // POST: ProjectUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userId,FirstName,LastName,Email")] ProjectUsers projectUsers)
        {
            if (id != projectUsers.userId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectUsersExists(projectUsers.userId))
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
            return View(projectUsers);
        }

        // GET: ProjectUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectUsers = await _context.ProjectUsers
                .FirstOrDefaultAsync(m => m.userId == id);
            if (projectUsers == null)
            {
                return NotFound();
            }

            return View(projectUsers);
        }

        // POST: ProjectUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectUsers = await _context.ProjectUsers.FindAsync(id);
            if (projectUsers != null)
            {
                _context.ProjectUsers.Remove(projectUsers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectUsersExists(int id)
        {
            return _context.ProjectUsers.Any(e => e.userId == id);
        }
    }
}
