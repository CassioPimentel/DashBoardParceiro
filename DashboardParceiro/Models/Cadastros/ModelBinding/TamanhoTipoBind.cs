using Microsoft.AspNetCore.Mvc.Rendering;

namespace DashboardParceiro.Models.Cadastros.ModelBinding
{
    public class TamanhoTipoBind
    {
        public Tamanho Tamanho { get; set; }
        public SelectList Tipos { get; set; }

        public int TipoId { get; set; }
    }
}