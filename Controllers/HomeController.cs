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
        public IActionResult Index()
        {

            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View();
        }
        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");

            return View();
        }

        // POST: Home/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UsuarioLogin usuario)
        {
            if (ModelState.IsValid)
            {
                var userAuthenticated = await _context.Usuarios.FirstOrDefaultAsync(u => u.UserMat == usuario.UserMat && u.UserSenha == usuario.UserSenha);
                Console.WriteLine(userAuthenticated);

                if (userAuthenticated != null)
                {
                    var authFactory = new AuthFactory(userAuthenticated);
                    var auth = authFactory.Create();
                    var token = auth.CreateToken();
                    Console.WriteLine(token);
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
