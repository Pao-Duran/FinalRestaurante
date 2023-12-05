using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebRestaurante.Models;

namespace WebRestaurante.Controllers
{
    [Authorize]
    public class ComidasController : Controller
    {
        private readonly LabRestauranteMpContext _context;

        public ComidasController(LabRestauranteMpContext context)
        {
            _context = context;
        }

        // GET: Comidas
        public async Task<IActionResult> Index()
        {
              return _context.Comida != null ? 
                          View(await _context.Comida.ToListAsync()) :
                          Problem("Entity set 'LabRestauranteMpContext.Comida'  is null.");
        }

        // GET: Comidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comida == null)
            {
                return NotFound();
            }

            var comidum = await _context.Comida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comidum == null)
            {
                return NotFound();
            }

            return View(comidum);
        }

        // GET: Comidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,UsuarioRegistro,FechaRegistro,Estado")] Comidum comidum)
        {
            if (!string.IsNullOrEmpty(comidum.Nombre) )
            {
                comidum.UsuarioRegistro = User.Identity?.Name;
                comidum.FechaRegistro = DateTime.Now;
                comidum.Estado = 1;
                _context.Add(comidum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comidum);
        }

        // GET: Comidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comida == null)
            {
                return NotFound();
            }

            var comidum = await _context.Comida.FindAsync(id);
            if (comidum == null)
            {
                return NotFound();
            }
            return View(comidum);
        }

        // POST: Comidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,UsuarioRegistro,FechaRegistro,Estado")] Comidum comidum)
        {
            if (id != comidum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comidum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComidumExists(comidum.Id))
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
            return View(comidum);
        }

        // GET: Comidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comida == null)
            {
                return NotFound();
            }

            var comidum = await _context.Comida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comidum == null)
            {
                return NotFound();
            }

            return View(comidum);
        }

        // POST: Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comida == null)
            {
                return Problem("Entity set 'LabRestauranteMpContext.Comida'  is null.");
            }
            var comidum = await _context.Comida.FindAsync(id);
            if (comidum != null)
            {
                _context.Comida.Remove(comidum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComidumExists(int id)
        {
          return (_context.Comida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
