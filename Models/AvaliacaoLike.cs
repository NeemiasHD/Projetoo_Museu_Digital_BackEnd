using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Museu_da_computacao.Models
{
    [Table("AvaliacaoLike")]
    public class AvaliacaoLike
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "IdUser")]
        [Column("IdUser")]
        public string IdUser { get; set; }



    }
}
