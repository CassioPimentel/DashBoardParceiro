using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardParceiro.Models.Cadastros
{
    public class Complemento
    {
        [Key]
        [Column("Id")]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
