using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UGB.Data;
using UGB.Interface;

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
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(await _context.EntradaEstoques.ToListAsync());
        }

        // GET: EntradaEstoque/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFoundError", "Error");

            }

            var entradaEstoque = await _context.EntradaEstoques.FirstOrDefaultAsync(m => m.EntradaId == id);
            if (entradaEstoque == null)
            {
                return RedirectToAction("NotFoundError", "Error");

            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Create
        [HttpGet("Create/{id}")]
        public IActionResult Create(int id)
        {
            TempData["Id"] = id;
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View();
        }

        // POST: EntradaEstoque/Create
        [HttpPost("Create/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] EntradaEstoque entradaEstoque, int id)
        {
            if (ModelState.IsValid)
            {
                DateOnly date = DateOnly.FromDateTime(DateTime.Today);
                IUsuario usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario"));
                IOrdemCompra ordem = await _context.OrdemCompras.FirstOrDefaultAsync(o => o.OrdemId == id);
                IPedidoInterno pedido = await _context.PedidoInternos.FirstOrDefaultAsync(p => p.PedidoId == ordem.PedidoInternoPedidoId);
                IProduto produto = await _context.Produtos.FindAsync(pedido.ProdutoProdEan);
                entradaEstoque.EntradaQuantidade = ordem.OrdemQuantidade;
                entradaEstoque.ProdutoProdEan = produto.ProdEan;
                entradaEstoque.UsuarioUserMat = usuario.UserMat;
                entradaEstoque.EntradaData = date;
                IEstoque estoqueExist = await _context.Estoques.FirstOrDefaultAsync(e => e.ProdutoProdEan == produto.ProdEan);
                _context.Add(entradaEstoque);
                await _context.SaveChangesAsync();
                if (estoqueExist == null)
                {
                    return RedirectToAction("Create", "Estoque", new { ean = entradaEstoque.ProdutoProdEan });
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFoundError", "Error");

            }

            var entradaEstoque = await _context.EntradaEstoques.FirstOrDefaultAsync(m => m.EntradaId == id);
            if (entradaEstoque == null)
            {
                return RedirectToAction("NotFoundError", "Error");

            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
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
