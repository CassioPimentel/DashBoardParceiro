using Microsoft.AspNetCore.Mvc.Rendering;
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
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("Codigo Personalizado")]
        public string CodPersonalizado { get; set; }

        [DisplayName("Cagetoria")]
        public long CategoriaID { get; set; }
        [DisplayName("Medida")]
        public long MedidaID { get; set; }
        public long ParceiroID { get; set; }

        [DisplayName("Preço de Custo")]
        public float PrecoCusto { get; set; }
        [DisplayName("Preço de Venda")]
        public float PrecoVenda { get; set; }
        public string CaminhoImagem { get; set; }

        [NotMapped]
        public SelectList Categorias { get; set; }
        [NotMapped]
        public SelectList Medidas { get; set; }

        [NotMapped]
        public virtual Categoria Categoria { get; set; }
        [NotMapped]
        public virtual ParceiroModel Parceiro { get; set; }
    }
}