using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UGB.Data;

namespace UGB.Controllers
{
    public class OrdemCompraController : Controller
    {
        private readonly UGBContext _context;

        public OrdemCompraController(UGBContext context)
        {
            _context = context;
        }

        // GET: OrdemCompra
        public async Task<IActionResult> Index()
        {
            var uGBContext = _context.OrdemCompras.Include(o => o.PedidoInterno);
            return View(await uGBContext.ToListAsync());
        }

        // GET: OrdemCompra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemCompra = await _context.OrdemCompras
                .Include(o => o.PedidoInterno)
                .FirstOrDefaultAsync(m => m.OrdemId == id);
            if (ordemCompra == null)
            {
                return NotFound();
            }

            return View(ordemCompra);
        }

        // GET: OrdemCompra/Create
        public IActionResult Create()
        {
            ViewData["PedidoInternoPedidoId"] = new SelectList(_context.PedidoInternos, "PedidoId", "PedidoId");
            return View();
        }

        // POST: OrdemCompra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdemId,OrdemQuantidade,OrdemPrecototal,PedidoInternoPedidoId,PedidoInternoUsuarioUserMat")] OrdemCompra ordemCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordemCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoInternoPedidoId"] = new SelectList(_context.PedidoInternos, "PedidoId", "PedidoId", ordemCompra.PedidoInternoPedidoId);
            return View(ordemCompra);
        }

        // GET: OrdemCompra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemCompra = await _context.OrdemCompras.FindAsync(id);
            if (ordemCompra == null)
            {
                return NotFound();
            }
            ViewData["PedidoInternoPedidoId"] = new SelectList(_context.PedidoInternos, "PedidoId", "PedidoId", ordemCompra.PedidoInternoPedidoId);
            return View(ordemCompra);
        }

        // POST: OrdemCompra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdemId,OrdemQuantidade,OrdemPrecototal,PedidoInternoPedidoId,PedidoInternoUsuarioUserMat")] OrdemCompra ordemCompra)
        {
            if (id != ordemCompra.OrdemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordemCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemCompraExists(ordemCompra.OrdemId))
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
            ViewData["PedidoInternoPedidoId"] = new SelectList(_context.PedidoInternos, "PedidoId", "PedidoId", ordemCompra.PedidoInternoPedidoId);
            return View(ordemCompra);
        }

        // GET: OrdemCompra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemCompra = await _context.OrdemCompras
                .Include(o => o.PedidoInterno)
                .FirstOrDefaultAsync(m => m.OrdemId == id);
            if (ordemCompra == null)
            {
                return NotFound();
            }

            return View(ordemCompra);
        }

        // POST: OrdemCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordemCompra = await _context.OrdemCompras.FindAsync(id);
            if (ordemCompra != null)
            {
                _context.OrdemCompras.Remove(ordemCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemCompraExists(int id)
        {
            return _context.OrdemCompras.Any(e => e.OrdemId == id);
        }
    }
}
