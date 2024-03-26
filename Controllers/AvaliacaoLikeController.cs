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
    public class AvaliacaoLikeController : Controller
    {
        private readonly Contexto _context;

        public AvaliacaoLikeController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> BuscarTodos()
        {
            if (_context.AvaliacoesLike != null)
            {
                var avaliacoes = await _context.AvaliacoesLike.ToListAsync();
                return Json(avaliacoes);
            }
            else
            {
                return Json(new { error = "Entity set 'Contexto.AvaliacoesLike' is null." });
            }
        }

        [HttpGet]
        public async Task<JsonResult> BuscarUm(string? id)
        {
            if (id == null || _context.AvaliacoesLike == null)
            {
                return Json(new { error = "Not Found" });
            }

            var avaliacaoLike = await _context.AvaliacoesLike.FirstOrDefaultAsync(m => m.IdUser == id);
            if (avaliacaoLike == null)
            {
                return Json(new { error = "Not Found" });
            }

            return Json(avaliacaoLike);
        }

        [HttpPost]
        public async Task<JsonResult> Gravar([FromBody] AvaliacaoLike avaliacaoLike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacaoLike);
                await _context.SaveChangesAsync();
                return Json(avaliacaoLike);
            }
            else
            {
                return Json(new { error = "Invalid model data" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Edit(int id, [FromBody] AvaliacaoLike avaliacaoLike)
        {
            if (id != avaliacaoLike.Id)
            {
                return Json(new { error = "Invalid ID" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacaoLike);
                    await _context.SaveChangesAsync();
                    return Json(new { message = "Avaliação atualizada com sucesso" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoLikeExists(avaliacaoLike.Id))
                    {
                        return Json(new { error = "Avaliação não encontrada" });
                    }
                    else
                    {
                        return Json(new { error = "Exceção de concorrência" });
                    }
                }
            }
            else
            {
                return Json(new { error = "Invalid model data" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Deletar(int id)
        {
            if (_context.AvaliacoesLike == null)
            {
                return Json(new { error = "Entity set 'Contexto.AvaliacoesLike' is null." });
            }

            var avaliacaoLike = await _context.AvaliacoesLike.FindAsync(id);
            if (avaliacaoLike != null)
            {
                _context.AvaliacoesLike.Remove(avaliacaoLike);
                await _context.SaveChangesAsync();
                return Json(new { message = "Avaliação removida com sucesso." });
            }
            else
            {
                return Json(new { error = "Avaliação não encontrada." });
            }
        }

        private bool AvaliacaoLikeExists(int id)
        {
            return (_context.AvaliacoesLike?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
