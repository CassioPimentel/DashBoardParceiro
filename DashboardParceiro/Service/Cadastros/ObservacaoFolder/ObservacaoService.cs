using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Repository.Cadastros.ObservacaoFolder;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.ObservacaoFolder
{
    public class ObservacaoService : IObservacaoService
    {
        private IObservacaoRepository _observacaoRepository;

        public ObservacaoService(IObservacaoRepository observacaoRepository)
        {
            _observacaoRepository = observacaoRepository;
        }

        public List<Observacao> GetAll()
        {
            return _observacaoRepository.GetAll();
        }

        public Observacao Save(Observacao categoria)
        {
            return _observacaoRepository.Save(categoria);
        }

        public int Excluir(int Id)
        {
            return _observacaoRepository.Excluir(Id);
        }

        public Observacao Get(int Id)
        {
            return _observacaoRepository.Get(Id);
        }
    }
}
