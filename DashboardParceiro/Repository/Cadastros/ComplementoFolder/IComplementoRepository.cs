using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Repository.Cadastros.ComplementoFolder
{
    public interface IComplementoRepository
    {
        List<Complemento> GetAll();
        Complemento Get(int Id);
        Complemento Save(Complemento Complemento);
        int Excluir(int Id);
    }
}
