using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_Museu_da_computacao.Models;

namespace API_Museu_da_computacao.Controllers
{
    public class AvaliacaoDeslikeController : Controller
    {
        private readonly Contexto _context;

        public AvaliacaoDeslikeController(Contexto context)
        {
            _context = context;
        }

        // GET: AvaliacaoDeslike
        public async Task<JsonResult> BuscarTodos()
        {
            var avaliacoesDeslike = await _context.AvaliacoesDeslike.ToListAsync();
            return Json(avaliacoesDeslike);
        }

        // GET: AvaliacaoDeslike/Details/5
        public async Task<JsonResult> BuscarUm(int? id)
        {
            if (id == null || _context.AvaliacoesDeslike == null)
            {
                return Json(new { error = "Not found" });
            }

            var avaliacaoDeslike = await _context.AvaliacoesDeslike.FirstOrDefaultAsync(m => m.Id == id);
            return Json(avaliacaoDeslike);
        }

        // GET: AvaliacaoDeslike/Create
        public JsonResult Create()
        {
            return Json(new { message = "Create method is not supported via JSON" });
        }

        // POST: AvaliacaoDeslike/Create
        [HttpPost]
        public async Task<JsonResult> Gravar([Bind("Id,IdUser")] AvaliacaoDeslike avaliacaoDeslike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacaoDeslike);
                await _context.SaveChangesAsync();
                return Json(avaliacaoDeslike);
            }
            return Json(new { error = "Invalid model state" });
        }

        // GET: AvaliacaoDeslike/Edit/5
        public async Task<JsonResult> Edit(int? id)
        {
            if (id == null || _context.AvaliacoesDeslike == null)
            {
                return Json(new { error = "Not found" });
            }

            var avaliacaoDeslike = await _context.AvaliacoesDeslike.FindAsync(id);
            return Json(avaliacaoDeslike);
        }

        // POST: AvaliacaoDeslike/Edit/5
        [HttpPost]
        public async Task<JsonResult> Edit(int id, [Bind("Id,IdUser")] AvaliacaoDeslike avaliacaoDeslike)
        {
            if (id != avaliacaoDeslike.Id)
            {
                return Json(new { error = "ID mismatch" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacaoDeslike);
                    await _context.SaveChangesAsync();
                    return Json(avaliacaoDeslike);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoDeslikeExists(avaliacaoDeslike.Id))
                    {
                        return Json(new { error = "Not found" });
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Json(new { error = "Invalid model state" });
        }

        // GET: AvaliacaoDeslike/Delete/5
        public async Task<JsonResult> Deletar(int? id)
        {
            if (id == null || _context.AvaliacoesDeslike == null)
            {
                return Json(new { error = "Not found" });
            }

            var avaliacaoDeslike = await _context.AvaliacoesDeslike.FirstOrDefaultAsync(m => m.Id == id);
            return Json(avaliacaoDeslike);
        }

        // POST: AvaliacaoDeslike/Delete/5
        [HttpPost]
        public async Task<JsonResult> Deletar(int id)
        {
            if (_context.AvaliacoesDeslike == null)
            {
                return Json(new { error = "Entity set 'Contexto.AvaliacoesDeslike' is null." });
            }

            var avaliacaoDeslike = await _context.AvaliacoesDeslike.FindAsync(id);
            if (avaliacaoDeslike != null)
            {
                _context.AvaliacoesDeslike.Remove(avaliacaoDeslike);
                await _context.SaveChangesAsync();
            }

            return Json(new { message = "Deleted successfully" });
        }

        private bool AvaliacaoDeslikeExists(int id)
        {
            return (_context.AvaliacoesDeslike?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
