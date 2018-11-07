using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardParceiro.Models.Cadastros
{
    public class Tamanho
    {
        [Key]
        [Column("Id")]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        [Column("TipoId")]
        public int TipoId { get; set; }
        
        [NotMapped]
        public SelectList Tipos { get; set; }

        //[NotMapped]
        //public virtual Tipo Tipo { get; set; }
    }
}
