using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroEstudiantil.Data;
using RegistroEstudiantil.Models;

namespace RegistroEstudiantil.Controllers
{
    public class notasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public notasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: notas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.notas.Include(n => n.Estudiantes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.notas == null)
            {
                return NotFound();
            }

            var notas = await _context.notas
                .Include(n => n.Estudiantes)
                .FirstOrDefaultAsync(m => m.IDNota == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // GET: notas/Create
        public IActionResult Create()
        {
            ViewData["IDEstudiantes"] = new SelectList(_context.Estudiantes, "IDEstudiantes", "IDEstudiantes");
            return View();
        }

        // POST: notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDNota,nota,IDEstudiantes,IDProfesores")] notas notas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDEstudiantes"] = new SelectList(_context.Estudiantes, "IDEstudiantes", "IDEstudiantes", notas.IDEstudiantes);
            return View(notas);
        }

        // GET: notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.notas == null)
            {
                return NotFound();
            }

            var notas = await _context.notas.FindAsync(id);
            if (notas == null)
            {
                return NotFound();
            }
            ViewData["IDEstudiantes"] = new SelectList(_context.Estudiantes, "IDEstudiantes", "IDEstudiantes", notas.IDEstudiantes);
            return View(notas);
        }

        // POST: notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDNota,nota,IDEstudiantes,IDProfesores")] notas notas)
        {
            if (id != notas.IDNota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!notasExists(notas.IDNota))
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
            ViewData["IDEstudiantes"] = new SelectList(_context.Estudiantes, "IDEstudiantes", "IDEstudiantes", notas.IDEstudiantes);
            return View(notas);
        }

        // GET: notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.notas == null)
            {
                return NotFound();
            }

            var notas = await _context.notas
                .Include(n => n.Estudiantes)
                .FirstOrDefaultAsync(m => m.IDNota == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // POST: notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.notas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.notas'  is null.");
            }
            var notas = await _context.notas.FindAsync(id);
            if (notas != null)
            {
                _context.notas.Remove(notas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool notasExists(int id)
        {
          return (_context.notas?.Any(e => e.IDNota == id)).GetValueOrDefault();
        }
    }
}
