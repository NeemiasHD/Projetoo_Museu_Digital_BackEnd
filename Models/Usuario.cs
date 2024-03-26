using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace API_Museu_da_computacao.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Display(Name = "IdUser")]
        [Column("IdUser")]
        public int Id { get; set; }

        [Display(Name = "UsuarioGoogleID")]
        [Column("UsuarioGoogleID")]
        public string UsuarioGoogleID { get; set; }
        [Display(Name = "SobreMim")]
        [Column("SobreMim")]
        public string ?SobreMim { get; set; }

        [Display(Name = "User_twitter_link")]
        [Column("User_twitter_link")]
        public string ?User_twitter_link { get; set; }
        [Display(Name = "User_insta_link")]
        [Column("User_insta_link")]
        public string? User_insta_link { get; set; }
        [Display(Name = "User_github_link")]
        [Column("User_github_link")]
        public string? User_github_link { get; set; }

        [Display(Name = "TipoUsuario")]
        [Column("TipoUsuario")]
        [Range(1, 2, ErrorMessage = "O Tipo de Usuário deve ser 1 ou 2")]
        public int TipoUsuario { get; set; }


    }
}
