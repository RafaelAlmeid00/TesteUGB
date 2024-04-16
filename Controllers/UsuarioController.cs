using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UGB.Data;
using UGB.Factory;

namespace UGB.Controllers
{
    [Route("Usuario/")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UGBContext _context;

        public UsuarioController(UGBContext context)
        {
            _context = context;
        }

        // GET: Usuario
        [HttpGet("/Usuario")]
        public async Task<IActionResult> Index()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuario/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UserMat == id);
            if (usuario == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(usuario);
        }

        // GET: Usuario/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View();
        }

        // POST: Usuario/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var cryptoFactory = new CryptoFactory(null, usuario.UserSenha);
                var crypto = cryptoFactory.Create();
                usuario.UserSenha = crypto.Encrypt();
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [FromForm] Usuario usuario)
        {
            if (id != usuario.UserMat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cryptoFactory = new CryptoFactory(null, usuario.UserSenha);
                    var crypto = cryptoFactory.Create();
                    usuario.UserSenha = crypto.Encrypt();
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UserMat))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UserMat == id);
            if (usuario == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuarios.Any(e => e.UserMat == id);
        }
    }

}
