using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardParceiro.Models.Cadastros
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string CodPersonalizado { get; set; }

        public long CategoriaID { get; set; }
        public long MedidaID { get; set; }
        public long ParceiroID { get; set; }

        public float PrecoCusto { get; set; }
        public float PrecoVenda { get; set; }

        public string CaminhoImagem { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ParceiroModel Parceiro { get; set; }
    }
}