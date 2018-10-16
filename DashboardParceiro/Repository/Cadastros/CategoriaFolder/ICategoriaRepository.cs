using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Repository.Cadastros.CategoriaFolder
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAll();
        Categoria Save(Categoria categoria);
    }
}
