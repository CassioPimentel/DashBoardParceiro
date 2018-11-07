using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Repository.Cadastros.TamanhoFolder;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.TamanhoFolder
{
    public class TamanhoService : ITamanhoService
    {
        private ITamanhoRepository _tamanhoRepository;

        public TamanhoService(ITamanhoRepository tamanhoRepository)
        {
            _tamanhoRepository = tamanhoRepository;
        }

        public int Excluir(int Id)
        {
            return _tamanhoRepository.Excluir(Id);
        }

        public Tamanho Get(int Id)
        {
            return _tamanhoRepository.Get(Id);
        }

        public List<Tamanho> GetAll()
        {
            return _tamanhoRepository.GetAll();
        }

        public Tamanho Save(Tamanho Tamanho)
        {
            return _tamanhoRepository.Save(Tamanho);
        }
    }
}
