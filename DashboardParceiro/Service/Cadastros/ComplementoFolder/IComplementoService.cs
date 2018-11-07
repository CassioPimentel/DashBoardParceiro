using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.ComplementoFolder
{
    public interface IComplementoService
    {
        List<Complemento> GetAll();
        Complemento Get(int Id);
        Complemento Save(Complemento Complemento);
        int Excluir(int Id);
    }
}
