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
    public class ItemAcervoController : Controller
    {
        private readonly Contexto _context;

        public ItemAcervoController(Contexto context)
        {
            _context = context;
        }

        //public async Task<JsonResult> BuscarTodos()
        //{
        //    if (_context.ItemAcervo != null)
        //    {
        //        var itemAcervo = await _context.ItemAcervo.ToListAsync();
        //        return Json(itemAcervo);
        //    }
        //    else
        //    {
        //        return Json(new { error = "Entity set 'Contexto.ItemAcervo' is null." });
        //    }
        //}
        /*Buscar Todos Com PAginacao*/
        [HttpGet]
        public async Task<JsonResult> BuscarTodos(int? page, int? pageSize)//paginação
        {
            try
            {
                // Defina valores padrão se nenhum valor for fornecido
                int currentPage = page ?? 1;
                IQueryable<ItemAcervo> query = _context.ItemAcervo;

                if (pageSize.HasValue)
                {
                    int itemsPerPage = pageSize.Value;
                    var totalItems = await query.CountAsync();
                    var totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

                    var ItensAcervo = await query
                        .Skip((currentPage - 1) * itemsPerPage)
                        .Take(itemsPerPage)
                        .ToListAsync();

                    var paginationHeader = new
                    {
                        TotalItems = totalItems,
                        TotalPages = totalPages,
                        CurrentPage = currentPage,
                        PageSize = itemsPerPage
                    };

                    Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

                    return Json(ItensAcervo);
                }
                else
                {
                    // Retorna todos os itens se pageSize não for fornecido
                    var ItensAcervo = await query.ToListAsync();
                    return Json(ItensAcervo);
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        public async Task<JsonResult> BuscarUm(int id)
        {
            if (id == null || _context.ItemAcervo == null)
            {
                return Json(new { error = "Not Found" });
            }

            var itemAcervo = await _context.ItemAcervo.FirstOrDefaultAsync(m => m.Id == id);
            if (itemAcervo == null)
            {
                return Json(new { error = "Not Found" });
            }

            return Json(itemAcervo);
        }

        [HttpPost]
        public async Task<JsonResult> Gravar([FromBody] ItemAcervo itemAcervo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemAcervo);
                await _context.SaveChangesAsync();
                return Json(itemAcervo);
            }
            else
            {
                return Json(new { error = "Invalid model data" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Alterar(int id, [FromBody] ItemAcervo itemAcervo)
        {
            if (id != itemAcervo.Id)
            {
                return Json(new { error = "Invalid ID" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemAcervo);
                    await _context.SaveChangesAsync();
                    return Json(new { message = "Usuario updated successfully" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(itemAcervo.Id))
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
            if (_context.ItemAcervo == null)
            {
                return Json(new { error = "Entity set 'Contexto.Produto' is null." });
            }

            var itemAcervo = await _context.ItemAcervo.FindAsync(id);
            if (itemAcervo != null)
            {
                _context.ItemAcervo.Remove(itemAcervo);
                await _context.SaveChangesAsync();
                return Json(new { message = "Produto removido com sucesso." });
            }
            else
            {
                return Json(new { error = "Produto não encontrado." });
            }
        }


        [HttpPost]
        public async Task<JsonResult> AdicionarLikeAoItem(int id, [FromBody] AvaliacaoLike avaliacaoLike)
        {
            // Verifica se o item de acervo existe
            var itemAcervo = await _context.ItemAcervo.FindAsync(id);
            if (itemAcervo == null)
            {
                return Json(new { error = "Item de acervo não encontrado." });
            }

            // Adiciona o like ao item de acervo
            if (itemAcervo.like == null)
            {
                itemAcervo.like = new List<AvaliacaoLike>();
            }
            itemAcervo.like.Add(avaliacaoLike);

            // Salva as mudanças
            await _context.SaveChangesAsync();

            return Json(new { message = "Like adicionado ao item de acervo com sucesso." });
        }
        [HttpPost]
        public async Task<JsonResult> AdicionarDesLikeAoItem(int id, [FromBody] AvaliacaoDeslike avaliacaoDeslike)
        {
            // Verifica se o item de acervo existe
            var itemAcervo = await _context.ItemAcervo.FindAsync(id);
            if (itemAcervo == null)
            {
                return Json(new { error = "Item de acervo não encontrado." });
            }

            // Adiciona o like ao item de acervo
            if (itemAcervo.Deslike == null)
            {
                itemAcervo.Deslike = new List<AvaliacaoDeslike>();
            }
            itemAcervo.Deslike.Add(avaliacaoDeslike);

            // Salva as mudanças
            await _context.SaveChangesAsync();

            return Json(new { message = "DesLike adicionado ao item de acervo com sucesso." });
        }
        [HttpGet]
        public async Task<JsonResult> UsuarioAvaliouLike(int itemId, string userId)
        {
            try
            {
                var itemAcervo = await _context.ItemAcervo
                    .Include(i => i.like)
                    .FirstOrDefaultAsync(i => i.Id == itemId);

                if (itemAcervo == null)
                {
                    return Json(new { error = "Item de acervo não encontrado." });
                }

                bool usuarioAvaliouLike = itemAcervo.like.Any(l => l.IdUser == userId);

                return Json(new { usuarioAvaliouLike });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        public async Task<JsonResult> UsuarioAvaliouDeslike(int itemId, string userId)
        {
            try
            {
                var itemAcervo = await _context.ItemAcervo
                    .Include(i => i.Deslike)
                    .FirstOrDefaultAsync(i => i.Id == itemId);

                if (itemAcervo == null)
                {
                    return Json(new { error = "Item de acervo não encontrado." });
                }

                bool usuarioAvaliouLike = itemAcervo.Deslike.Any(l => l.IdUser == userId);

                return Json(new { usuarioAvaliouLike });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<JsonResult> RemoverLikeDoItem(int id, string IdUser)
        {
            try
            {
                // Localiza o item de acervo pelo ID
                var itemAcervo = await _context.ItemAcervo
                    .Include(i => i.like)
                    .FirstOrDefaultAsync(i => i.Id == id);

                if (itemAcervo == null)
                {
                    return Json(new { error = "Item de acervo não encontrado." });
                }

                // Verifica se existe um like associado ao usuário com o ID fornecido
                var likeToRemove = itemAcervo.like.FirstOrDefault(l => l.IdUser == IdUser);
                if (likeToRemove != null)
                {
                    // Remove o like da coleção de likes do item de acervo
                    itemAcervo.like.Remove(likeToRemove);
                    await _context.SaveChangesAsync();
                    return Json(new { message = "Like removido com sucesso." });
                }
                else
                {
                    return Json(new { error = "Like não encontrado para o usuário especificado." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<JsonResult> RemoverDeslikeDoItem(int id, string IdUser)
        {
            try
            {
                // Localiza o item de acervo pelo ID
                var itemAcervo = await _context.ItemAcervo
                    .Include(i => i.Deslike)
                    .FirstOrDefaultAsync(i => i.Id == id);

                if (itemAcervo == null)
                {
                    return Json(new { error = "Item de acervo não encontrado." });
                }

                // Verifica se existe um like associado ao usuário com o ID fornecido
                var likeToRemove = itemAcervo.Deslike.FirstOrDefault(l => l.IdUser == IdUser);
                if (likeToRemove != null)
                {
                    // Remove o like da coleção de likes do item de acervo
                    itemAcervo.Deslike.Remove(likeToRemove);
                    await _context.SaveChangesAsync();
                    return Json(new { message = "Deslike removido com sucesso." });
                }
                else
                {
                    return Json(new { error = "Deslike não encontrado para o usuário especificado." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        private bool ProdutoExists(int id)
        {
            return (_context.ItemAcervo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
