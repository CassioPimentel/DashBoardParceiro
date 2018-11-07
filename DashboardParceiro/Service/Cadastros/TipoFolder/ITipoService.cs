using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.TipoFolder
{
    public interface ITipoService
    {
        List<Tipo> GetAll();
        Tipo Get(int Id);
        Tipo Save(Tipo Tipo);
        int Excluir(int Id);
    }
}
