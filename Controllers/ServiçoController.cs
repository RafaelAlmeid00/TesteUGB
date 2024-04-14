using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UGB.Data;

namespace UGB.Controllers
{
    public class ServiçoController : Controller
    {
        private readonly UGBContext _context;

        public ServiçoController(UGBContext context)
        {
            _context = context;
        }

        // GET: Serviço
        public async Task<IActionResult> Index()
        {
            var uGBContext = _context.Serviços.Include(s => s.FornecedorFornecedorCnpjNavigation).Include(s => s.UsuarioUserMatNavigation);
            return View(await uGBContext.ToListAsync());
        }

        // GET: Serviço/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviço = await _context.Serviços
                .Include(s => s.FornecedorFornecedorCnpjNavigation)
                .Include(s => s.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.ServId == id);
            if (serviço == null)
            {
                return NotFound();
            }

            return View(serviço);
        }

        // GET: Serviço/Create
        public IActionResult Create()
        {
            ViewData["FornecedorFornecedorCnpj"] = new SelectList(_context.Fornecedors, "FornecedorCnpj", "FornecedorCnpj");
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat");
            return View();
        }

        // POST: Serviço/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServId,ServNome,ServDescricao,ServPrazo,UsuarioUserMat,FornecedorFornecedorCnpj")] Serviço serviço)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviço);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorFornecedorCnpj"] = new SelectList(_context.Fornecedors, "FornecedorCnpj", "FornecedorCnpj", serviço.FornecedorFornecedorCnpj);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", serviço.UsuarioUserMat);
            return View(serviço);
        }

        // GET: Serviço/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviço = await _context.Serviços.FindAsync(id);
            if (serviço == null)
            {
                return NotFound();
            }
            ViewData["FornecedorFornecedorCnpj"] = new SelectList(_context.Fornecedors, "FornecedorCnpj", "FornecedorCnpj", serviço.FornecedorFornecedorCnpj);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", serviço.UsuarioUserMat);
            return View(serviço);
        }

        // POST: Serviço/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServId,ServNome,ServDescricao,ServPrazo,UsuarioUserMat,FornecedorFornecedorCnpj")] Serviço serviço)
        {
            if (id != serviço.ServId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["FornecedorFornecedorCnpj"] = new SelectList(_context.Fornecedors, "FornecedorCnpj", "FornecedorCnpj", serviço.FornecedorFornecedorCnpj);
            ViewData["UsuarioUserMat"] = new SelectList(_context.Usuarios, "UserMat", "UserMat", serviço.UsuarioUserMat);
            return View(serviço);
        }

        // GET: Serviço/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviço = await _context.Serviços
                .Include(s => s.FornecedorFornecedorCnpjNavigation)
                .Include(s => s.UsuarioUserMatNavigation)
                .FirstOrDefaultAsync(m => m.ServId == id);
            if (serviço == null)
            {
                return NotFound();
            }

            return View(serviço);
        }

        // POST: Serviço/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviço = await _context.Serviços.FindAsync(id);
            if (serviço != null)
            {
                _context.Serviços.Remove(serviço);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiçoExists(int id)
        {
            return _context.Serviços.Any(e => e.ServId == id);
        }
    }
}
