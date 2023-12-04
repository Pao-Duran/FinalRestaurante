using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebRestaurante.Models;

namespace WebRestaurante.Controllers
{
    public class FacturasController : Controller
    {
        private readonly LabRestauranteMpContext _context;

        public FacturasController(LabRestauranteMpContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var labRestauranteMpContext = _context.Facturas.Include(f => f.IdBebidaNavigation).Include(f => f.IdClienteNavigation).Include(f => f.IdComidaNavigation).Include(f => f.IdEmpleadoNavigation);
            return View(await labRestauranteMpContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdBebidaNavigation)
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdComidaNavigation)
                .Include(f => f.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["IdBebida"] = new SelectList(_context.Bebida, "Id", "Id");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["IdComida"] = new SelectList(_context.Comida, "Id", "Id");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Id");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,IdEmpleado,IdComida,IdBebida,UsuarioRegistro,FechaRegistro,Estado")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBebida"] = new SelectList(_context.Bebida, "Id", "Id", factura.IdBebida);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", factura.IdCliente);
            ViewData["IdComida"] = new SelectList(_context.Comida, "Id", "Id", factura.IdComida);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Id", factura.IdEmpleado);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IdBebida"] = new SelectList(_context.Bebida, "Id", "Id", factura.IdBebida);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", factura.IdCliente);
            ViewData["IdComida"] = new SelectList(_context.Comida, "Id", "Id", factura.IdComida);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Id", factura.IdEmpleado);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,IdEmpleado,IdComida,IdBebida,UsuarioRegistro,FechaRegistro,Estado")] Factura factura)
        {
            if (id != factura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.Id))
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
            ViewData["IdBebida"] = new SelectList(_context.Bebida, "Id", "Id", factura.IdBebida);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", factura.IdCliente);
            ViewData["IdComida"] = new SelectList(_context.Comida, "Id", "Id", factura.IdComida);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Id", factura.IdEmpleado);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdBebidaNavigation)
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdComidaNavigation)
                .Include(f => f.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facturas == null)
            {
                return Problem("Entity set 'LabRestauranteMpContext.Facturas'  is null.");
            }
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
          return (_context.Facturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
