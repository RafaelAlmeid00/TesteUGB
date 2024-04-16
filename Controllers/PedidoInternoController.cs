using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UGB.Data;

namespace UGB.Controllers
{
    [Route("PedidoInterno/")]
    [ApiController]
    public class PedidoInternoController : Controller
    {
        private readonly UGBContext _context;

        public PedidoInternoController(UGBContext context)
        {
            _context = context;
        }

        // GET: PedidoInterno
        [HttpGet("/PedidoInterno")]
        public async Task<IActionResult> Index()
        {
            List<PedidoInterno> pedidosInternos = await _context.PedidoInternos.ToListAsync();
            List<OrdemCompra> ordensCompra = await _context.OrdemCompras.ToListAsync();
            List<int> indicesParaRemover = new List<int>();

            for (int i = 0; i < pedidosInternos.Count; i++)
            {
                foreach (var ordemCompra in ordensCompra)
                {
                    if (pedidosInternos[i].PedidoId == ordemCompra.PedidoInternoPedidoId)
                    {
                        indicesParaRemover.Add(i);
                        break;
                    }
                }
            }

            foreach (var item in pedidosInternos)
            {
                if (item.ProdutoProdEan != null)
                {
                    var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.ProdEan == item.ProdutoProdEan);
                    item.ProdutoNome = produto.ProdNome;
                    Console.WriteLine("prduto" + produto);
                    Console.WriteLine("pedido" + item);

                }
                if (item.ServicoServId != null)
                {
                    var serviço = await _context.Serviços.FirstOrDefaultAsync(m => m.ServId == item.ServicoServId);
                    item.ServicoNome = serviço.ServNome;
                    Console.WriteLine("prduto" + serviço);
                    Console.WriteLine("pedido" + item);
                }
            }

            foreach (var indice in indicesParaRemover.OrderByDescending(x => x))
            {
                pedidosInternos.RemoveAt(indice);
            }
            Console.WriteLine("pedido" + pedidosInternos);
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(pedidosInternos);
        }

        // GET: PedidoInterno/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoInterno = await _context.PedidoInternos.FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoInterno == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(pedidoInterno);
        }

        // GET: PedidoInterno/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewData["Serviços"] = new SelectList(_context.Serviços, "ServId", "ServId");
            ViewData["Produtos"] = new SelectList(_context.Produtos, "ProdEan", "ProdEan");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View();
        }

        // POST: PedidoInterno/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] PedidoInterno pedidoInterno)
        {
            Console.WriteLine(pedidoInterno.SelectValue);
            if (pedidoInterno.SelectValue != "Produto")
            {
                Console.WriteLine("Serviço" + pedidoInterno.SelectValue);
                pedidoInterno.ProdutoProdEan = null;
            }
            if (pedidoInterno.SelectValue != "Serviço")
            {
                Console.WriteLine("Produto" + pedidoInterno.SelectValue);
                pedidoInterno.ServicoServId = null;
            }

            if (ModelState.IsValid)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario").ToString());
                pedidoInterno.UsuarioUserMat = usuario.UserMat;
                _context.Add(pedidoInterno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoInterno);
        }

        // GET: PedidoInterno/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoInterno = await _context.PedidoInternos.FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoInterno == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");

            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", pedidoInterno.UsuarioUserMat);
            return View(pedidoInterno);
        }

        // POST: PedidoInterno/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] PedidoInterno pedidoInterno)
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
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoInterno = await _context.PedidoInternos.FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoInterno == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(pedidoInterno);
        }

        // POST: PedidoInterno/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoInterno = await _context.PedidoInternos.FirstOrDefaultAsync(m => m.PedidoId == id);
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
