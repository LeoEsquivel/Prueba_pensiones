using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_Nomina;
using Prueba_Nomina.Entities;

namespace Prueba_Nomina.Controllers
{
    public class DatosGeneralesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatosGeneralesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DatosGenerales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pensionados.Include(p => p.estado_Civil).Include(p => p.tipo_Pension);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DatosGenerales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pensionados == null)
            {
                return NotFound();
            }

            var pensionado = await _context.Pensionados
                .Include(p => p.estado_Civil)
                .Include(p => p.tipo_Pension)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pensionado == null)
            {
                return NotFound();
            }

            return View(pensionado);
        }

        // GET: DatosGenerales/Create
        public IActionResult Create()
        {
            ViewData["Estado_civilId"] = new SelectList(_context.Estados_Civiles, "Id", "Estado");
            ViewData["Tipo_PensionId"] = new SelectList(_context.Tipo_Pensiones, "Id", "Tipo");
            return View();
        }

        // POST: DatosGenerales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,No_activo,Cobro_indebido,Status_pago,Clave_pension,No_afiliado,No_pension,Sexo,ApellidoP,ApellidoM,Nombre,Fecha_nacimiento,RFC,CURP,Email,Estado_civilId,Tipo_PensionId")] Pensionado pensionado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pensionado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Estado_civilId"] = new SelectList(_context.Estados_Civiles, "Id", "Estado", pensionado.Estado_civilId);
            ViewData["Tipo_PensionId"] = new SelectList(_context.Tipo_Pensiones, "Id", "Tipo", pensionado.Tipo_PensionId);
            return View(pensionado);
        }

        // GET: DatosGenerales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pensionados == null)
            {
                return NotFound();
            }

            var pensionado = await _context.Pensionados.FindAsync(id);
            if (pensionado == null)
            {
                return NotFound();
            }
            ViewData["Estado_civilId"] = new SelectList(_context.Estados_Civiles, "Id", "Estado", pensionado.Estado_civilId);
            ViewData["Tipo_PensionId"] = new SelectList(_context.Tipo_Pensiones, "Id", "Tipo", pensionado.Tipo_PensionId);
            return View(pensionado);
        }

        // POST: DatosGenerales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,No_activo,Cobro_indebido,Status_pago,Clave_pension,No_afiliado,No_pension,Sexo,ApellidoP,ApellidoM,Nombre,Fecha_nacimiento,RFC,CURP,Email,Estado_civilId,Tipo_PensionId")] Pensionado pensionado)
        {
            if (id != pensionado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pensionado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PensionadoExists(pensionado.Id))
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
            ViewData["Estado_civilId"] = new SelectList(_context.Estados_Civiles, "Id", "Estado", pensionado.Estado_civilId);
            ViewData["Tipo_PensionId"] = new SelectList(_context.Tipo_Pensiones, "Id", "Tipo", pensionado.Tipo_PensionId);
            return View(pensionado);
        }

        // GET: DatosGenerales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pensionados == null)
            {
                return NotFound();
            }

            var pensionado = await _context.Pensionados
                .Include(p => p.estado_Civil)
                .Include(p => p.tipo_Pension)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pensionado == null)
            {
                return NotFound();
            }

            return View(pensionado);
        }

        // POST: DatosGenerales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pensionados == null)
            {
                return Problem("Error al conectar con la base de datos");
            }
            var pensionado = await _context.Pensionados.FindAsync(id);
            if (pensionado != null)
            {
                _context.Pensionados.Remove(pensionado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PensionadoExists(int id)
        {
          return _context.Pensionados.Any(e => e.Id == id);
        }
    }
}
