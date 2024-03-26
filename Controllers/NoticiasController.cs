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
    public class NoticiasController : Controller
    {
        private readonly Contexto _context;

        public NoticiasController(Contexto context)
        {
            _context = context;
        }

        public async Task<JsonResult> BuscarTodos()
        {
            if (_context.Noticias != null)
            {
                var noticias = await _context.Noticias.ToListAsync();
                return Json(noticias);
            }
            else
            {
                return Json(new { error = "Entity set 'Contexto.Noticias' is null." });
            }
        }


        // [HttpGet]
        // public async Task<JsonResult> BuscarTodos(int? page, int? pageSize)//paginação
        // {
        //     try
        //     {
        //         // Defina valores padrão se nenhum valor for fornecido
        //         int currentPage = page ?? 1;
        //         int itemsPerPage = pageSize ?? 500;

        //         var totalItems = await _context.Produto.CountAsync();
        //         var totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

        //         var produtos = await _context.Produto
        //             .Skip((currentPage - 1) * itemsPerPage)
        //             .Take(itemsPerPage)
        //             .ToListAsync();

        //         var paginationHeader = new
        //         {
        //             TotalItems = totalItems,
        //             TotalPages = totalPages,
        //             CurrentPage = currentPage,
        //             PageSize = itemsPerPage
        //         };

        //         Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

        //         return Json(produtos);
        //     }
        //     catch (Exception ex)
        //     {
        //         return Json(new { error = ex.Message });
        //     }
        // }

        public async Task<JsonResult> BuscarUm(int? id)
        {
            if (id == null || _context.Noticias == null)
            {
                return Json(new { error = "Not Found" });
            }

            var noticias = await _context.Noticias.FirstOrDefaultAsync(m => m.Id == id);
            if (noticias == null)
            {
                return Json(new { error = "Not Found" });
            }

            return Json(noticias);
        }

        [HttpPost]
        public async Task<JsonResult> Gravar([FromBody] Noticias noticias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticias);
                await _context.SaveChangesAsync();
                return Json(noticias);
            }
            else
            {
                return Json(new { error = "Invalid model data" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Alterar(int id, [FromBody] Noticias noticias)
        {
            if (id != noticias.Id)
            {
                return Json(new { error = "Invalid ID" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticias);
                    await _context.SaveChangesAsync();
                    return Json(new { message = "Usuario updated successfully" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(noticias.Id))
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
            if (_context.Noticias == null)
            {
                return Json(new { error = "Entity set 'Contexto.Produto' is null." });
            }

            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias != null)
            {
                _context.Noticias.Remove(noticias);
                await _context.SaveChangesAsync();
                return Json(new { message = "Produto removido com sucesso." });
            }
            else
            {
                return Json(new { error = "Produto não encontrado." });
            }
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Noticias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
