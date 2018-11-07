using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Repository.Cadastros.ObservacaoFolder
{
    public interface IObservacaoRepository
    {
        List<Observacao> GetAll();
        Observacao Get(int Id);
        Observacao Save(Observacao categoria);
        int Excluir(int Id);
    }
}