using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Models.Cadastros.ModelBinding;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.TamanhoTipoFolder
{
    public interface ITamanhoTipoService
    {
        List<ComplementoCategoria> GetCategoriaVinculado(int CodigoComplemento);
        List<ComplementoCategoria> GetCategorias(int CodigoCategoria);
        string Save(ComplementoCategoriaBind Model);
        void Excluir(int CodigoComplemento);
    }
}
