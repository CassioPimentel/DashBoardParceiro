using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardParceiro.Models.Cadastros
{
    public class TamanhoTipo
    {
        [Key]
        [Column("Id")]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }
        [Column("CodigoTamanho")]
        public int CodigoTamanho { get; set; }
        [Column("CodigoTipo")]
        public int CodigoTipo { get; set; }

        [NotMapped]
        public virtual Tamanho Tamanho { get; set; }
        [NotMapped]
        public virtual Tipo Tipo { get; set; }
    }
}