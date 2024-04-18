using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UGB.Data;
using UGB.Interface;

namespace UGB.Controllers
{
    [Route("EstoqueSaida/")]
    [ApiController]
    public class SaidaEstoqueController : Controller
    {
        private readonly UGBContext _context;

        public SaidaEstoqueController(UGBContext context)
        {
            _context = context;
        }

        // GET: SaidaEstoque
        [HttpGet("/EstoqueSaida")]
        public async Task<IActionResult> Index()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(await _context.SaidaEstoques.ToListAsync());
        }

        // GET: SaidaEstoque/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFoundError", "Error");
            }

            var saidaEstoque = await _context.SaidaEstoques.FirstOrDefaultAsync(m => m.SaidaId == id);
            if (saidaEstoque == null)
            {
                return RedirectToAction("NotFoundError", "Error");
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(saidaEstoque);
        }

        // GET: SaidaEstoque/Create
        [HttpGet("Create/{id}")]
        public IActionResult Create(string id)
        {
            TempData["ean"] = id;
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View();
        }

        // POST: SaidaEstoque/Create
        [HttpPost("Create/{ean}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] SaidaEstoque saidaEstoque, string ean)
        {
            if (ModelState.IsValid)
            {
                DateOnly date = DateOnly.FromDateTime(DateTime.Today);
                IUsuario usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario"));
                IProduto produto = await _context.Produtos.FindAsync(ean);
                saidaEstoque.ProdutoProdEan = ean;
                saidaEstoque.UsuarioUserMat = usuario.UserMat;
                saidaEstoque.EntradaData = date;
                _context.Add(saidaEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saidaEstoque);
        }

        // GET: SaidaEstoque/Delete/5
        [HttpGet("Delete{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFoundError", "Error");
            }

            var saidaEstoque = await _context.SaidaEstoques.FirstOrDefaultAsync(m => m.SaidaId == id);
            if (saidaEstoque == null)
            {
                return RedirectToAction("NotFoundError", "Error");
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(saidaEstoque);
        }

        // POST: SaidaEstoque/Delete/5
        [HttpPost("Delete/{id}")]
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
