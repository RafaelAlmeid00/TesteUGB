using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        [HttpGet("/Produto")]
        public async Task<IActionResult> Index()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produto/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.ProdEan == id);
            if (produto == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");

            return View(produto);
        }

        // GET: Produto/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            ViewData["Fornecedor"] = new SelectList(_context.Fornecedors, "FornecedorNome", "FornecedorNome");

            return View();
        }

        // POST: Produto/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Produto produto)
        {

            if (ModelState.IsValid)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario").ToString());
                produto.UsuarioUserMat = usuario.UserMat;
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        // GET: Produto/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string? id)
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
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            ViewData["Fornecedor"] = new SelectList(_context.Fornecedors, "FornecedorNome", "FornecedorNome");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", produto.UsuarioUserMat);
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [FromForm] Produto produto)
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

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.ProdEan == id);
            if (produto == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(string id)
        {
            return _context.Produtos.Any(e => e.ProdEan == id);
        }
    }
}
