using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Repository.Cadastros.TipoFolder
{
    public interface ITipoRepository
    {
        List<Tipo> GetAll();
        Tipo Get(int Id);
        Tipo Save(Tipo Tipo);
        int Excluir(int Id);
    }
}
