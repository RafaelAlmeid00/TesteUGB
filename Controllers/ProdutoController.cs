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
    [Route("Produto/")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly UGBContext _context;

        public ProdutoController(UGBContext context)
        {
            _context = context;
        }

        // GET: Produto
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var uGBContext = _context.Produtos.Include(p => p.UsuarioUserMatNavigation);
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produto/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.ProdEan == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        [HttpGet("Create/n")]
        public IActionResult Create()
        {
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create/Novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdEan,ProdNome,ProdPreco,ProdFabricante,ProdEstoqueminimo,UsuarioUserMat")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", produto.UsuarioUserMat);
            return View(produto);
        }

        // GET: Produto/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", produto.UsuarioUserMat);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdEan,ProdNome,ProdPreco,ProdFabricante,ProdEstoqueminimo,UsuarioUserMat")] Produto produto)
        {
            if (id != produto.ProdEan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdEan))
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
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", produto.UsuarioUserMat);
            return View(produto);
        }

        // GET: Produto/Delete/5
        [HttpGet("Delete/{id}")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.ProdEan == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdEan == id);
        }
    }
}
