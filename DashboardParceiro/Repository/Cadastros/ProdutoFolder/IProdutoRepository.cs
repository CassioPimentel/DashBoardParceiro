using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Repository.Cadastros.ProdutoFolder
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();
        Produto Get(int Id);
        Produto Save(Produto Tamanho);
        int Excluir(int Id);
    }
}
