using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardParceiro.Models.Cadastros
{
    [Table("Observacao")]
    public class Observacao
    {
        [Key]
        [Column("Id")]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }
        [Column("Descricao")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
