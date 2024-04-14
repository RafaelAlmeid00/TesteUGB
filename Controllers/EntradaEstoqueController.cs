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
    public class EntradaEstoqueController : Controller
    {
        private readonly UGBContext _context;

        public EntradaEstoqueController(UGBContext context)
        {
            _context = context;
        }

        // GET: EntradaEstoque
        public async Task<IActionResult> Index()
        {
            var uGBContext = _context.EntradaEstoques.Include(e => e.ProdutoProdEanNavigation).Include(e => e.UsuarioUserMatNavigation);
            return View(await uGBContext.ToListAsync());
        }

        // GET: EntradaEstoque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradaEstoque = await _context.EntradaEstoques
                .Include(e => e.ProdutoProdEanNavigation)
                .Include(e => e.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.EntradaId == id);
            if (entradaEstoque == null)
            {
                return NotFound();
            }

            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Create
        public IActionResult Create()
        {
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            return View();
        }

        // POST: EntradaEstoque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntradaId,EntradaNf,EntradaDeposito,EntradaQuantidade,EntradaData,UsuarioUserMat,ProdutoProdEan")] EntradaEstoque entradaEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan", entradaEstoque.ProdutoProdEan);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", entradaEstoque.UsuarioUserMat);
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradaEstoque = await _context.EntradaEstoques.FindAsync(id);
            if (entradaEstoque == null)
            {
                return NotFound();
            }
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan", entradaEstoque.ProdutoProdEan);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", entradaEstoque.UsuarioUserMat);
            return View(entradaEstoque);
        }

        // POST: EntradaEstoque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntradaId,EntradaNf,EntradaDeposito,EntradaQuantidade,EntradaData,UsuarioUserMat,ProdutoProdEan")] EntradaEstoque entradaEstoque)
        {
            if (id != entradaEstoque.EntradaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaEstoqueExists(entradaEstoque.EntradaId))
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
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan", entradaEstoque.ProdutoProdEan);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", entradaEstoque.UsuarioUserMat);
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradaEstoque = await _context.EntradaEstoques
                .Include(e => e.ProdutoProdEanNavigation)
                .Include(e => e.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.EntradaId == id);
            if (entradaEstoque == null)
            {
                return NotFound();
            }

            return View(entradaEstoque);
        }

        // POST: EntradaEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entradaEstoque = await _context.EntradaEstoques.FindAsync(id);
            if (entradaEstoque != null)
            {
                _context.EntradaEstoques.Remove(entradaEstoque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaEstoqueExists(int id)
        {
            return _context.EntradaEstoques.Any(e => e.EntradaId == id);
        }
    }
}
