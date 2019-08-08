using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Controllers
{
    public class MensagemsController : Controller
    {
        private readonly BlogContext _context;

        public MensagemsController(BlogContext context)
        {
            _context = context;
        }

        // GET: Mensagems
        public async Task<IActionResult> Index()
        {
            var blogContext = _context.Mensagem.Include(m => m.Categorias).Include(m => m.Comentarios);
            return View(await blogContext.ToListAsync());
        }

        // GET: Mensagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Categorias)
                .Include(m => m.Comentarios)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // GET: Mensagems/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId");
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId");
            return View();
        }

        // POST: Mensagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MensagemId,Titulo,Descricao,ComentarioId,CategoriaId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            return View(mensagem);
        }

        // GET: Mensagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            return View(mensagem);
        }

        // POST: Mensagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MensagemId,Titulo,Descricao,ComentarioId,CategoriaId")] Mensagem mensagem)
        {
            if (id != mensagem.MensagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemExists(mensagem.MensagemId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            return View(mensagem);
        }

        // GET: Mensagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Categorias)
                .Include(m => m.Comentarios)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // POST: Mensagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagem = await _context.Mensagem.FindAsync(id);
            _context.Mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemExists(int id)
        {
            return _context.Mensagem.Any(e => e.MensagemId == id);
        }
    }
}
