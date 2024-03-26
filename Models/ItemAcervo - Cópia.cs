﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Museu_da_computacao.Models

{
    [Table("ItensAcervo")]
    public class ItemAcervo
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }
        [Display(Name = "NomeItem")]
        [Column("NomeItem")]
        public string NomeItem { get; set; }
        [Display(Name = "DescricaoItem")]
        [Column("DescricaoItem")]
        public string DescricaoItem { get; set; }
        [Display(Name = "NotaItemLike")]
        [Column("NotaItemLike")]
        public int NotaItemLike { get; set; }
        [Display(Name = "NotaItemDesLike")]
        [Column("NotaItemDesLike")]
        public int NotaItemDesLike { get; set; }
        [Display(Name = "Imagem1Item")]
        [Column("Imagem1Item")]
        public string Imagem1Item { get; set; }



    }
}
