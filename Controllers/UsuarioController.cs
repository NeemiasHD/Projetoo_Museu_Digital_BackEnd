using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Museu_da_computacao.Models;

namespace API_Museu_da_computacao.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Contexto _context;

        public UsuarioController(Contexto context)
        {
            _context = context;
        }

        public async Task<JsonResult> BuscarTodos()
        {
            if (_context.Usuario != null)
            {
                var usuarios = await _context.Usuario.ToListAsync();
                return Json(usuarios);
            }
            else
            {
                return Json(new { error = "Entity set 'Contexto.Usuario' is null." });
            }
        }

        public async Task<JsonResult> BuscarUm(string? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return Json(new { error = "Not Found" });
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.UsuarioGoogleID == id);
            if (usuario == null)
            {
                return Json(new { error = "Not Found" });
            }

            return Json(usuario);
        }

        [HttpPost]
        public async Task<JsonResult> Gravar([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return Json(usuario);
            }
            else
            {
                return Json(new { error = "Invalid model data" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Alterar(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return Json(new { error = "Invalid ID" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                    return Json(new { message = "Usuario updated successfully" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return Json(new { error = "Usuario not found" });
                    }
                    else
                    {
                        return Json(new { error = "Concurrency exception" });
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
            if (_context.Usuario == null)
            {
                return Json(new { error = "Entity set 'Contexto.Usuario' is null." });
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                return Json(new { message = "Usuario removido com sucesso." });
            }
            else
            {
                return Json(new { error = "Usuario não encontrado." });
            }
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
