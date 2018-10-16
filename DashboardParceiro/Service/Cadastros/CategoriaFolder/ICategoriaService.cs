using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.CategoriaFolder
{
    public interface ICategoriaService
    {
        List<Categoria> GetAll();
        Categoria Save(Categoria categoria);
    }
}
