using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardParceiro.Models.Cadastros
{
    public class ComplementoCategoria
    {
        [Key]
        [Column("Id")]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }
        [Column("CodigoComplemento")]
        public int CodigoComplemento { get; set; }
        [Column("CodigoCategoria")]
        public int CodigoCategoria { get; set; }
        [Column("CodigoParceiro")]
        public int CodigoParceiro { get; set; }

        [NotMapped]
        public virtual Categoria Categoria { get; set; }
        [NotMapped]
        public virtual Complemento Complemento { get; set; }
        [NotMapped]
        public virtual ParceiroModel ParceiroModel { get; set; }
    }
}
