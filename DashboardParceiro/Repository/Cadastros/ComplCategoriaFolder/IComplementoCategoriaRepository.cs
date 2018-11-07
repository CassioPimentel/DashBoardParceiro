using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Models.Cadastros.ModelBinding;
using System.Collections.Generic;

namespace DashboardParceiro.Repository.Cadastros.ComplCategoriaFolder
{
    public interface IComplementoCategoriaRepository
    {
        List<ComplementoCategoria> GetCategoriaVinculado(int CodigoComplemento);
        List<ComplementoCategoria> GetCategorias(int CodigoCategoria);
        string Save(ComplementoCategoriaBind Model);
        int Excluir(int CodigoComplemento);
    }
}