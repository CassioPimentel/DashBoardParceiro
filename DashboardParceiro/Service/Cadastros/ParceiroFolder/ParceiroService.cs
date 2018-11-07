using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Repository.Cadastros.ParceiroFolder;

namespace DashboardParceiro.Service.Cadastros.ParceiroFolder
{
    public class ParceiroService : IParceiroService
    {
        private IParceiroRepository _parceiroRepository;

        public ParceiroService(IParceiroRepository parceiroRepository)
        {
            _parceiroRepository = parceiroRepository;
        }

        public ParceiroModel Get(int Id)
        {
            return _parceiroRepository.Get(Id);
        }

        public ParceiroModel Save(ParceiroModel Parceiro)
        {
            return _parceiroRepository.Save(Parceiro);
        }
    }
}