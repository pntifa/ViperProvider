using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Viper.Models;

namespace MVC_Viper.Controllers
{
    public class ProgramsController : Controller
    {
        private readonly ProviderDBContext _context;

        public ProgramsController(ProviderDBContext context)
        {
            _context = context;
        }

        // GET: Programs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programs.ToListAsync());
        }

        // GET: Programs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programs = await _context.Programs
                .FirstOrDefaultAsync(m => m.ProgramName == id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // GET: Programs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramName,Benefits,Charge")] Programs programs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programs);
        }

        // GET: Programs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programs = await _context.Programs.FindAsync(id);
            if (programs == null)
            {
                return NotFound();
            }
            return View(programs);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProgramName,Benefits,Charge")] Programs programs)
        {
            if (id != programs.ProgramName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramsExists(programs.ProgramName))
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
            return View(programs);
        }

        // GET: Programs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programs = await _context.Programs
                .FirstOrDefaultAsync(m => m.ProgramName == id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var programs = await _context.Programs.FindAsync(id);
            if (programs != null)
            {
                _context.Programs.Remove(programs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramsExists(string id)
        {
            return _context.Programs.Any(e => e.ProgramName == id);
        }
    }
}
