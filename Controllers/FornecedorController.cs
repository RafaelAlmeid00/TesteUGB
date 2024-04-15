using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UGB.Data;

namespace UGB.Controllers
{
    [Route("Fornecedor/")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private readonly UGBContext _context;

        public FornecedorController(UGBContext context)
        {
            _context = context;
        }

        // GET: Fornecedor
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(await _context.Fornecedors.ToListAsync());
        }

        // GET: Fornecedor/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedors.FirstOrDefaultAsync(m => m.FornecedorCnpj == id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            return View();
        }

        // POST: Fornecedor/Create

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario").ToString());
                fornecedor.UsuarioUserMat = usuario.UserMat;
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                Console.WriteLine(id);
                return NotFound();
            }

            var fornecedor = await _context.Fornecedors.FindAsync(id);
            if (fornecedor == null)
            {
                Console.WriteLine(fornecedor);

                return NotFound();
            }
            Console.WriteLine(fornecedor);
            Console.WriteLine(id);

            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", fornecedor.UsuarioUserMat);
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [FromForm] Fornecedor fornecedor)
        {
            if (id != fornecedor.FornecedorCnpj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.FornecedorCnpj))
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
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", fornecedor.UsuarioUserMat);
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedors
                .FirstOrDefaultAsync(m => m.FornecedorCnpj == id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fornecedor = await _context.Fornecedors.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedors.Remove(fornecedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(string id)
        {
            return _context.Fornecedors.Any(e => e.FornecedorCnpj == id);
        }
    }
}
