using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardParceiro.Models.Cadastros
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Column("Id")]
        [DisplayName("Codigo")]

        public long Codigo { get; set; }
        [Column("Descricao")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        //public long ParceiroId { get; set; }

        //public virtual ParceiroModel Parceiro { get; set; }
    }
}