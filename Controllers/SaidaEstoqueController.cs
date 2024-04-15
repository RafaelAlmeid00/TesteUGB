using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UGB.Data;

namespace UGB.Controllers
{
    public class SaidaEstoqueController : Controller
    {
        private readonly UGBContext _context;

        public SaidaEstoqueController(UGBContext context)
        {
            _context = context;
        }

        // GET: SaidaEstoque
        public async Task<IActionResult> Index()
        {
            var uGBContext = _context.SaidaEstoques.Include(s => s.ProdutoProdEanNavigation).Include(s => s.UsuarioUserMatNavigation);
            return View(await uGBContext.ToListAsync());
        }

        // GET: SaidaEstoque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaEstoque = await _context.SaidaEstoques
                .Include(s => s.ProdutoProdEanNavigation)
                .Include(s => s.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.SaidaId == id);
            if (saidaEstoque == null)
            {
                return NotFound();
            }

            return View(saidaEstoque);
        }

        // GET: SaidaEstoque/Create
        public IActionResult Create()
        {
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            return View();
        }

        // POST: SaidaEstoque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaidaId,SaidaQuantidade,EntradaData,UsuarioUserMat,ProdutoProdEan")] SaidaEstoque saidaEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saidaEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan", saidaEstoque.ProdutoProdEan);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", saidaEstoque.UsuarioUserMat);
            return View(saidaEstoque);
        }

        // GET: SaidaEstoque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaEstoque = await _context.SaidaEstoques.FindAsync(id);
            if (saidaEstoque == null)
            {
                return NotFound();
            }
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan", saidaEstoque.ProdutoProdEan);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", saidaEstoque.UsuarioUserMat);
            return View(saidaEstoque);
        }

        // POST: SaidaEstoque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaidaId,SaidaQuantidade,EntradaData,UsuarioUserMat,ProdutoProdEan")] SaidaEstoque saidaEstoque)
        {
            if (id != saidaEstoque.SaidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saidaEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaidaEstoqueExists(saidaEstoque.SaidaId))
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
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan", saidaEstoque.ProdutoProdEan);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", saidaEstoque.UsuarioUserMat);
            return View(saidaEstoque);
        }

        // GET: SaidaEstoque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaEstoque = await _context.SaidaEstoques
                .Include(s => s.ProdutoProdEanNavigation)
                .Include(s => s.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.SaidaId == id);
            if (saidaEstoque == null)
            {
                return NotFound();
            }

            return View(saidaEstoque);
        }

        // POST: SaidaEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saidaEstoque = await _context.SaidaEstoques.FindAsync(id);
            if (saidaEstoque != null)
            {
                _context.SaidaEstoques.Remove(saidaEstoque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaidaEstoqueExists(int id)
        {
            return _context.SaidaEstoques.Any(e => e.SaidaId == id);
        }
    }
}
