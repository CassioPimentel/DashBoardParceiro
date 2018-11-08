using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardParceiro.Models.Cadastros
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [Column("Id")]
        [DisplayName("Codigo")]
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public string CodPersonalizado { get; set; }

        public long CategoriaID { get; set; }
        public long MedidaID { get; set; }
        public long ParceiroID { get; set; }

        public float PrecoCusto { get; set; }
        public float PrecoVenda { get; set; }

        public string CaminhoImagem { get; set; }

        [NotMapped]
        public virtual Categoria Categoria { get; set; }
        [NotMapped]
        public virtual ParceiroModel Parceiro { get; set; }
    }
}