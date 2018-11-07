using Microsoft.AspNetCore.Mvc.Rendering;

namespace DashboardParceiro.Models.Cadastros.ModelBinding
{
    public class ComplementoCategoriaBind
    {
        public Complemento Complemento { get; set; }
        public SelectList Categorias { get; set; }

        public int[] CategoriaIds { get; set; }
    }
}