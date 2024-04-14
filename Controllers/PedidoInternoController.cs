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
    public class PedidoInternoController : Controller
    {
        private readonly UGBContext _context;

        public PedidoInternoController(UGBContext context)
        {
            _context = context;
        }

        // GET: PedidoInterno
        public async Task<IActionResult> Index()
        {
            var uGBContext = _context.PedidoInternos.Include(p => p.UsuarioUserMatNavigation);
            return View(await uGBContext.ToListAsync());
        }

        // GET: PedidoInterno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoInterno = await _context.PedidoInternos
                .Include(p => p.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoInterno == null)
            {
                return NotFound();
            }

            return View(pedidoInterno);
        }

        // GET: PedidoInterno/Create
        public IActionResult Create()
        {
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            return View();
        }

        // POST: PedidoInterno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,PedidoQuantidade,PedidoData,UsuarioUserMat,ProdutoProdEan,ServiçoServId")] PedidoInterno pedidoInterno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoInterno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", pedidoInterno.UsuarioUserMat);
            return View(pedidoInterno);
        }

        // GET: PedidoInterno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoInterno = await _context.PedidoInternos.FindAsync(id);
            if (pedidoInterno == null)
            {
                return NotFound();
            }
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", pedidoInterno.UsuarioUserMat);
            return View(pedidoInterno);
        }

        // POST: PedidoInterno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,PedidoQuantidade,PedidoData,UsuarioUserMat,ProdutoProdEan,ServiçoServId")] PedidoInterno pedidoInterno)
        {
            if (id != pedidoInterno.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoInterno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoInternoExists(pedidoInterno.PedidoId))
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
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", pedidoInterno.UsuarioUserMat);
            return View(pedidoInterno);
        }

        // GET: PedidoInterno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoInterno = await _context.PedidoInternos
                .Include(p => p.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoInterno == null)
            {
                return NotFound();
            }

            return View(pedidoInterno);
        }

        // POST: PedidoInterno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoInterno = await _context.PedidoInternos.FindAsync(id);
            if (pedidoInterno != null)
            {
                _context.PedidoInternos.Remove(pedidoInterno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoInternoExists(int id)
        {
            return _context.PedidoInternos.Any(e => e.PedidoId == id);
        }
    }
}
