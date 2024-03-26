using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Museu_da_computacao.Models
{
    [Table("AvaliacaoDeslike")]
    public class AvaliacaoDeslike
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "IdUser")]
        [Column("IdUser")]
        public string IdUser { get; set; }

    }
}
