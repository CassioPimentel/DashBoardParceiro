using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.CategoriaFolder
{
    public interface ICategoriaService
    {
        List<Categoria> GetAll();
        List<Categoria> GetCategorias(int[] Ids);
        Categoria Get(int Id);
        Categoria Save(Categoria categoria);
        int Excluir(int Id);
    }
}
