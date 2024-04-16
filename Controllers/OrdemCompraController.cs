using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UGB.Data;
using UGB.Interface;

namespace UGB.Controllers
{
    [Route("OrdemCompra/")]
    [ApiController]
    public class OrdemCompraController : Controller
    {
        private readonly UGBContext _context;

        public OrdemCompraController(UGBContext context)
        {
            _context = context;
        }

        // GET: OrdemCompra
        [HttpGet("/OrdemCompra")]
        public async Task<IActionResult> Index()
        {
            List<PedidoInterno> pedidosInternos = await _context.PedidoInternos.ToListAsync();
            List<OrdemCompra> ordemCompras = await _context.OrdemCompras.ToListAsync();
            foreach (var item in ordemCompras)
            {
                IPedidoInterno pedido = await _context.PedidoInternos.FirstOrDefaultAsync(p => p.PedidoId == item.PedidoInternoPedidoId);

                if (pedido.ServicoServId != null)
                {
                    IServiço serviço = await _context.Serviços.FirstOrDefaultAsync(s => s.ServId == pedido.ServicoServId);
                    item.ServicoNome = serviço.ServNome;
                }
                if (pedido.ProdutoProdEan != null)
                {
                    IProduto produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdEan == pedido.ProdutoProdEan);
                    item.ProdutoNome = produto.ProdNome;
                }
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(ordemCompras);
        }

        // GET: OrdemCompra/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemCompra = await _context.OrdemCompras.FirstOrDefaultAsync(m => m.OrdemId == id);
            if (ordemCompra == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(ordemCompra);
        }

        // GET: OrdemCompra/Create/5
        [HttpGet("Create/{id}")]
        public async Task<IActionResult> Create(int id)
        {
            IPedidoInterno pedidoInterno = await _context.PedidoInternos.FirstOrDefaultAsync(p => p.PedidoId == id);
            IProduto produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdEan == pedidoInterno.ProdutoProdEan);
            TempData["Produto"] = JsonConvert.SerializeObject(produto);
            TempData["PedidoInterno"] = JsonConvert.SerializeObject(pedidoInterno);
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View();
        }

        // POST: OrdemCompra/Create

        [HttpPost("Create/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] OrdemCompra ordemCompra, int id)
        {
            if (ModelState.IsValid)
            {
                IPedidoInterno pedidoInterno = await _context.PedidoInternos.FirstOrDefaultAsync(p => p.PedidoId == id);
                IProduto produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdEan == pedidoInterno.ProdutoProdEan);
                var usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario").ToString());
                ordemCompra.PedidoInternoUsuarioUserMat = usuario.UserMat;
                ordemCompra.PedidoInternoPedidoId = pedidoInterno.PedidoId;
                ordemCompra.OrdemPrecototal = (decimal)(produto.ProdPreco * ordemCompra.OrdemQuantidade);
                _context.Add(ordemCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoInternoPedidoId"] = new SelectList(_context.PedidoInternos, "PedidoId", "PedidoId", ordemCompra.PedidoInternoPedidoId);
            return View(ordemCompra);
        }

        [HttpGet("CreateService/{id}")]
        public async Task<IActionResult> CreateService(int id)
        {
            IPedidoInterno pedidoInterno = await _context.PedidoInternos.FirstOrDefaultAsync(p => p.PedidoId == id);
            if (pedidoInterno == null)
            {
                // Lidar com o caso em que não há pedido interno com o ID fornecido
                return NotFound();
            }

            int? servicoServId = pedidoInterno.ServicoServId;
            if (servicoServId == null)
            {
                // Lidar com o caso em que o ServicoServId é nulo
                return BadRequest("ServicoServId é nulo.");
            }

            IServiço serviço = await _context.Serviços.FirstOrDefaultAsync(s => s.ServId == servicoServId);
            if (serviço == null)
            {
                // Lidar com o caso em que não há serviço com o ID fornecido
                return NotFound();
            }

            TempData["Serviço"] = JsonConvert.SerializeObject(serviço);
            TempData["PedidoInterno"] = JsonConvert.SerializeObject(pedidoInterno);
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View();
        }



        [HttpPost("CreateService/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateService([FromForm] OrdemCompra ordemCompra, int id)
        {
            if (ModelState.IsValid)
            {
                IPedidoInterno pedidoInterno = await _context.PedidoInternos.FirstOrDefaultAsync(p => p.PedidoId == id);
                IServiço serviço = await _context.Serviços.FirstOrDefaultAsync(s => s.ServId == pedidoInterno.ServicoServId);
                var usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario").ToString());
                ordemCompra.PedidoInternoUsuarioUserMat = usuario.UserMat;
                ordemCompra.PedidoInternoPedidoId = pedidoInterno.PedidoId;
                ordemCompra.OrdemPrecototal = 0;
                _context.Add(ordemCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoInternoPedidoId"] = new SelectList(_context.PedidoInternos, "PedidoId", "PedidoId", ordemCompra.PedidoInternoPedidoId);
            return View(ordemCompra);
        }

        // GET: OrdemCompra/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemCompra = await _context.OrdemCompras.FirstOrDefaultAsync(m => m.OrdemId == id);
            if (ordemCompra == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(ordemCompra);
        }

        // POST: OrdemCompra/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordemCompra = await _context.OrdemCompras.FirstOrDefaultAsync(m => m.OrdemId == id);

            if (ordemCompra != null)
            {
                _context.OrdemCompras.Remove(ordemCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemCompraExists(int id)
        {
            return _context.OrdemCompras.Any(e => e.OrdemId == id);
        }
    }
}
