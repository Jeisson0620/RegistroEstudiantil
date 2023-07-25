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
    public class InscripcionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscripcionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inscripciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Inscripciones.Include(i => i.Cursos).Include(i => i.Estudiantes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscripciones == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones
                .Include(i => i.Cursos)
                .Include(i => i.Estudiantes)
                .FirstOrDefaultAsync(m => m.ID_inscripcion == id);
            if (inscripciones == null)
            {
                return NotFound();
            }

            return View(inscripciones);
        }

        // GET: Inscripciones/Create
        public IActionResult Create()
        {
            ViewData["ID_cursos"] = new SelectList(_context.Cursos, "IDCursos", "IDCursos");
            ViewData["IDEstudiantes"] = new SelectList(_context.Estudiantes, "IDEstudiantes", "IDEstudiantes");
            return View();
        }

        // POST: Inscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_inscripcion,Fecha_Inscripcion,IDEstudiantes,ID_cursos")] Inscripciones inscripciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_cursos"] = new SelectList(_context.Cursos, "IDCursos", "IDCursos", inscripciones.ID_cursos);
            ViewData["IDEstudiantes"] = new SelectList(_context.Estudiantes, "IDEstudiantes", "IDEstudiantes", inscripciones.IDEstudiantes);
            return View(inscripciones);
        }

        // GET: Inscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscripciones == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones.FindAsync(id);
            if (inscripciones == null)
            {
                return NotFound();
            }
            ViewData["ID_cursos"] = new SelectList(_context.Cursos, "IDCursos", "IDCursos", inscripciones.ID_cursos);
            ViewData["IDEstudiantes"] = new SelectList(_context.Estudiantes, "IDEstudiantes", "IDEstudiantes", inscripciones.IDEstudiantes);
            return View(inscripciones);
        }

        // POST: Inscripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_inscripcion,Fecha_Inscripcion,IDEstudiantes,ID_cursos")] Inscripciones inscripciones)
        {
            if (id != inscripciones.ID_inscripcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionesExists(inscripciones.ID_inscripcion))
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
            ViewData["ID_cursos"] = new SelectList(_context.Cursos, "IDCursos", "IDCursos", inscripciones.ID_cursos);
            ViewData["IDEstudiantes"] = new SelectList(_context.Estudiantes, "IDEstudiantes", "IDEstudiantes", inscripciones.IDEstudiantes);
            return View(inscripciones);
        }

        // GET: Inscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscripciones == null)
            {
                return NotFound();
            }

            var inscripciones = await _context.Inscripciones
                .Include(i => i.Cursos)
                .Include(i => i.Estudiantes)
                .FirstOrDefaultAsync(m => m.ID_inscripcion == id);
            if (inscripciones == null)
            {
                return NotFound();
            }

            return View(inscripciones);
        }

        // POST: Inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscripciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Inscripciones'  is null.");
            }
            var inscripciones = await _context.Inscripciones.FindAsync(id);
            if (inscripciones != null)
            {
                _context.Inscripciones.Remove(inscripciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionesExists(int id)
        {
          return (_context.Inscripciones?.Any(e => e.ID_inscripcion == id)).GetValueOrDefault();
        }
    }
}
