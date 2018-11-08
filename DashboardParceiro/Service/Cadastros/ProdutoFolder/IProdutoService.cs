using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.ProdutoFolder
{
    public interface IProdutoService
    {
        List<Produto> GetAll();
        Produto Get(int Id);
        Produto Save(Produto Tamanho);
        int Excluir(int Id);
    }
}
