using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Models.Cadastros.ModelBinding;
using System.Collections.Generic;

namespace DashboardParceiro.Repository.Cadastros.TamanhoTipoFolder
{
    public interface ITamanhoTipoRepository
    {
        List<ComplementoCategoria> GetCategoriaVinculado(int CodigoComplemento);
        List<ComplementoCategoria> GetCategorias(int CodigoCategoria);
        string Save(ComplementoCategoriaBind Model);
        int Excluir(int CodigoComplemento);
    }
}