using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using UGB.Data;
using UGB.Factory;
using UGB.Interface;

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
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            var order = JsonConvert.SerializeObject(await _context.PedidoInternos.ToListAsync());
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
                        var errorEncrypt = new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Erro ao logar!" };
                        TempData["ErrorView"] = JsonConvert.SerializeObject(errorEncrypt);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    var errorFind = new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Erro ao logar!" };
                    TempData["ErrorView"] = JsonConvert.SerializeObject(errorFind);
                    return RedirectToAction("Index");
                }
            }
            var errorAll = new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Erro ao logar!" };
            TempData["ErrorView"] = JsonConvert.SerializeObject(errorAll);
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
