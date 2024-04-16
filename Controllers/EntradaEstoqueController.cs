using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UGB.Data;

namespace UGB.Controllers
{
    [Route("EstoqueEntrada/")]
    [ApiController]
    public class EntradaEstoqueController : Controller
    {
        private readonly UGBContext _context;

        public EntradaEstoqueController(UGBContext context)
        {
            _context = context;
        }

        // GET: EntradaEstoque
        [HttpGet("/EntradaEstoque")]
        public async Task<IActionResult> Index()
        {
            var uGBContext = _context.EntradaEstoques.Include(e => e.ProdutoProdEanNavigation).Include(e => e.UsuarioUserMatNavigation);
            return View(await uGBContext.ToListAsync());
        }

        // GET: EntradaEstoque/Details/5
        [HttpGet("Details/{id}")]
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
        [HttpGet("Create/{id}")]
        public IActionResult Create(int? id)
        {
            ViewData["ProdutoProdEan"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            return View();
        }

        // POST: EntradaEstoque/Create
        [HttpPost("Create/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] EntradaEstoque entradaEstoque, int id)
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

        // GET: EntradaEstoque/Delete/5
        [HttpGet("Delete/{id}")]
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
        [HttpPost("Delete/{id}")]
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
