using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DashboardParceiro.Models.Cadastros
{
    [Table("Medida")]
    public class Medida
    {
        [Key]
        [Column("Id")]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }
        [Column("Descricao")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public static List<Medida> GetAll()
        {
            var context = new Context();
            return context.Medida.ToList();
        }
    }

}