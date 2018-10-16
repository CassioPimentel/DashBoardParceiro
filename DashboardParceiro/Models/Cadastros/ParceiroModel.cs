using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardParceiro.Models.Cadastros
{
    [Table("Parceiro")]
    public class ParceiroModel
    {
        [Key]
        public long Id { get; set; }
        public string Descricao { get; set; }

        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string InscEstadual { get; set; }

        public string FonePrincipal { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}