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
            List<EntradaEstoque> entradas = await _context.EntradaEstoques.ToListAsync();
            List<SaidaEstoque> saidas = await _context.SaidaEstoques.ToListAsync();
            List<Estoque> estoques = await _context.Estoques.ToListAsync();
            foreach (var item in estoques)
            {
                foreach (var entrada in entradas)
                {
                    if (entrada.ProdutoProdEan == item.ProdutoProdEan)
                    {
                        item.Quantidade += entrada.EntradaQuantidade;
                    }
                }

                foreach (var saida in saidas)
                {
                    if (saida.ProdutoProdEan == item.ProdutoProdEan)
                    {
                        item.Quantidade -= saida.SaidaQuantidade;
                    }
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
                    }
                    else
                    {
                        item.StatusEstoque = "OK";
                    }
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
                return RedirectToAction("NotFoundError", "Error");
            }

            var estoque = await _context.Estoques
                .FirstOrDefaultAsync(m => m.EstoqueId == id);
            if (estoque == null)
            {
                return RedirectToAction("NotFoundError", "Error");
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");

            return View(estoque);

        }


        [HttpGet("Create/{ean}")]
        public IActionResult Create(string ean)
        {
            TempData["ean"] = ean;
            return View();
        }

        // POST: Estoque/Create
        [HttpPost("Create/{ean}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Estoque estoque, string ean)
        {
            if (ModelState.IsValid)
            {
                estoque.ProdutoProdEan = ean;
                estoque.Quantidade = 0;
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
                return RedirectToAction("NotFoundError", "Error");
            }

            var estoque = await _context.Estoques
                .FirstOrDefaultAsync(m => m.EstoqueId == id);
            if (estoque == null)
            {
                return RedirectToAction("NotFoundError", "Error");
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
