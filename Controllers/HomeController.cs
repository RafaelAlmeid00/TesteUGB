using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using UGB.Data;
using UGB.Factory;

namespace UGB.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UGBContext _context;

        public HomeController(ILogger<HomeController> logger, UGBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("/")]
        public async Task<IActionResult> IndexAsync()
        {
            TempData["PedidoInterno"] = HttpContext.Session.GetString("PedidoInterno");
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
            var order = JsonConvert.SerializeObject(pedidosInternos);
            HttpContext.Session.SetString("PedidoInterno", order);
            TempData["PedidoInterno"] = HttpContext.Session.GetString("PedidoInterno");
            return View();
        }

    [HttpGet("Privacy")]
    public IActionResult Privacy()
    {
        TempData["Usuario"] = HttpContext.Session.GetString("Usuario");

        return View();
    }

    // POST: Home/Login
    public async Task<IActionResult> Login([FromForm] UsuarioLogin usuario)
    {
        if (ModelState.IsValid)
        {
            var userAuthenticated = await _context.Usuarios.FirstOrDefaultAsync(u => u.UserMat == usuario.UserMat);

            if (userAuthenticated != null)
            {
                var cryptoFactory = new CryptoFactory(userAuthenticated.UserSenha, usuario.UserSenha);
                var crypto = cryptoFactory.Create();
                var decrypt = crypto.Decrypt();

                if (decrypt)
                {
                    var authFactory = new AuthFactory(userAuthenticated);
                    var auth = authFactory.Create();
                    var token = auth.CreateToken();
                    HttpContext.Session.SetString("AuthToken", token);

                    var usuarioFactory = new UsuarioFactory();
                    var viewUser = (Usuario)usuarioFactory.Create();
                    viewUser.UserMat = userAuthenticated.UserMat;
                    viewUser.UserNome = userAuthenticated.UserNome;
                    viewUser.UserEmail = userAuthenticated.UserEmail;
                    viewUser.UserSenha = userAuthenticated.UserSenha;
                    viewUser.UserDepartamento = userAuthenticated.UserDepartamento;

                    var usuarioJson = JsonConvert.SerializeObject(viewUser);
                    HttpContext.Session.SetString("Usuario", usuarioJson);
                    TempData["Usuario"] = usuarioJson;

                    return RedirectToAction("Index");
                }
                else
                {
                    var errorMessage = new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Usuario ou Senha incorreta." };
                    TempData["ErrorView"] = JsonConvert.SerializeObject(errorMessage);
                }
            }
            else
            {
                var errorMessage = new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Usuário não encontrado. Cadastre-se" };
                TempData["ErrorView"] = JsonConvert.SerializeObject(errorMessage);
            }
        }
        else
        {
            var errorMessage = new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Por favor, preencha todos os campos." };
            TempData["ErrorView"] = JsonConvert.SerializeObject(errorMessage);
        }

        return RedirectToAction("Index");
    }


    [HttpGet("Home/Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
