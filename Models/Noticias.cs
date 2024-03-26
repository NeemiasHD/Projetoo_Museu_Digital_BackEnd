using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Museu_da_computacao.Models

{
    [Table("Noticias")]
    public class Noticias
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }
        [Display(Name = "TituloNoticia")]
        [Column("TituloNoticia")]
        public string TituloNoticia { get; set; }
        [Display(Name = "DescricaoNoticia")]
        [Column("DescricaoNoticia")]
        public string DescricaoNoticia { get; set; }
        [Display(Name = "tagNoticia")]
        [Column("tagNoticia")]
        public string tagNoticia { get; set; }
        [Display(Name = "ImagemNoticia")]
        [Column("ImagemNoticia")]
        public string Imagem1Item { get; set; }



    }
}
