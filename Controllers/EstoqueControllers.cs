using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UGB.Data;
using UGB.Interface;

namespace UGB.Controllers
{
    [Route("Estoque/")]
    [ApiController]
    public class EstoqueController : Controller
    {
        private readonly UGBContext _context;

        public EstoqueController(UGBContext context)
        {
            _context = context;
        }

        // GET: Estoque
        [HttpGet("/Estoque")]
        public async Task<IActionResult> Index()
        {
            List<Estoque> estoques = await _context.Estoques.ToListAsync();
            foreach (var item in estoques)
            {
                IProduto produto = await _context.Produtos.FindAsync(item.ProdutoProdEan);
                item.ProdutoNome = produto.ProdNome;
                item.EstoqueMinimo = produto.ProdEstoqueminimo;
                if (int.Parse(item.EstoqueMinimo) > item.Quantidade)
                {
                    item.StatusEstoque = "Alerta";
                }
                else if (int.Parse(item.EstoqueMinimo) == item.Quantidade)
                {
                    item.StatusEstoque = "Aviso";
                } else {
                    item.StatusEstoque = "OK";
                }
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");

            return View(estoques);
        }

        // GET: Estoque/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoques
                .FirstOrDefaultAsync(m => m.EstoqueId == id);
            if (estoque == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");

            return View(estoque);
        }

        // POST: Estoque/Create
        [HttpPost("Create/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Estoque estoque, int id)
        {
            if (ModelState.IsValid)
            {
                IOrdemCompra ordem = await _context.OrdemCompras.FirstOrDefaultAsync(o => o.OrdemId == id);
                IPedidoInterno pedido = await _context.PedidoInternos.FirstOrDefaultAsync(p => p.PedidoId == ordem.PedidoInternoPedidoId);
                IProduto produto = await _context.Produtos.FindAsync(pedido.ProdutoProdEan);
                estoque.Quantidade = ordem.OrdemQuantidade;
                estoque.ProdutoProdEan = produto.ProdEan;
                IEstoque estoqueExist = await _context.Estoques.FirstOrDefaultAsync(e => e.ProdutoProdEan == produto.ProdEan);
                if (estoqueExist != null)
                {
                    return RedirectToAction("Create", "EntradaEstoque", new { id });
                }
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estoque);
        }


        // GET: Estoque/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoques
                .FirstOrDefaultAsync(m => m.EstoqueId == id);
            if (estoque == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");

            return View(estoque);
        }

        // POST: Estoque/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            _context.Estoques.Remove(estoque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(int id)
        {
            return _context.Estoques.Any(e => e.EstoqueId == id);
        }
    }
}
