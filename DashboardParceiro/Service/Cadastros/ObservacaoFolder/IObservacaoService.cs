using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.ObservacaoFolder
{
    public interface IObservacaoService
    {
        List<Observacao> GetAll();
        Observacao Get(int Id);
        Observacao Save(Observacao categoria);
        int Excluir(int Id);
    }
}
