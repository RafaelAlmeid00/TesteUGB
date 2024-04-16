using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UGB.Data;
using UGB.Interface;

namespace UGB.Controllers
{
    [Route("Serviço/")]
    [ApiController]
    public class ServiçoController : Controller
    {
        private readonly UGBContext _context;

        public ServiçoController(UGBContext context)
        {
            _context = context;
        }

        // GET: Serviço
        [HttpGet("/Serviço")]
        public async Task<IActionResult> Index()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(await _context.Serviços.ToListAsync());
        }

        // GET: Serviço/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviço = await _context.Serviços.FirstOrDefaultAsync(m => m.ServId == id);
            if (serviço == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(serviço);
        }

        // GET: Serviço/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            ViewData["FornecedorCnpj"] = new SelectList(_context.Fornecedors, "FornecedorCnpj", "FornecedorCnpj");
            return View();
        }

        // POST: Serviço/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Serviço serviço)
        {
            if (ModelState.IsValid)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario").ToString());
                serviço.UsuarioUserMat = usuario.UserMat;
                Console.WriteLine(usuario);
                Console.WriteLine(serviço);
                _context.Add(serviço);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviço);
        }

        // GET: Serviço/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviço = await _context.Serviços.FirstOrDefaultAsync(s => s.ServId == id);
            if (serviço == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            ViewData["FornecedorFornecedorCnpj"] = new SelectList(_context.Fornecedors, "FornecedorCnpj", "FornecedorCnpj", serviço.FornecedorFornecedorCnpj);
            return View(serviço);
        }

        // POST: Serviço/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [FromForm] Serviço serviço)
        {
            if (id != serviço.ServId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario").ToString());
                    serviço.UsuarioUserMat = usuario.UserMat;
                    _context.Update(serviço);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiçoExists(serviço.ServId))
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
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            ViewData["FornecedorFornecedorCnpj"] = new SelectList(_context.Fornecedors, "FornecedorCnpj", "FornecedorCnpj", serviço.FornecedorFornecedorCnpj);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", serviço.UsuarioUserMat);
            return View(serviço);
        }

        // GET: Serviço/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviço = await _context.Serviços.FirstOrDefaultAsync(m => m.ServId == id);
            if (serviço == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(serviço);
        }

        // POST: Serviço/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var serviço = await _context.Serviços.FirstOrDefaultAsync(s => s.ServId == id);
            if (serviço != null)
            {
                _context.Serviços.Remove(serviço);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiçoExists(int? id)
        {
            return _context.Serviços.Any(e => e.ServId == id);
        }
    }
}
