using System.ComponentModel.DataAnnotations;

namespace DashboardParceiro.Models.Cadastros
{
    public class Estabelecimento
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public long ParceiroId { get; set; }

        public virtual ParceiroModel Parceiro { get; set; }
    }
}