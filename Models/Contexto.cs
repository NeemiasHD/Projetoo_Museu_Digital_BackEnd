using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API_Museu_da_computacao.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<ItemAcervo> ItemAcervo { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<AvaliacaoLike> AvaliacoesLike { get; set; }
        public DbSet<AvaliacaoDeslike> AvaliacoesDeslike { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Habilita o carregamento preguiçoso
        }
    }
}
