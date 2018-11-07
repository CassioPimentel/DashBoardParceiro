using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Repository.Cadastros.ComplementoFolder;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.ComplementoFolder
{
    public class ComplementoService : IComplementoService
    {
        private IComplementoRepository _complementoRepository;

        public ComplementoService(IComplementoRepository complementoRepository)
        {
            _complementoRepository = complementoRepository;
        }

        public int Excluir(int Id)
        {
            return _complementoRepository.Excluir(Id);
        }

        public Complemento Get(int Id)
        {
            return _complementoRepository.Get(Id);
        }

        public List<Complemento> GetAll()
        {
            return _complementoRepository.GetAll();
        }

        public Complemento Save(Complemento Complemento)
        {
            return _complementoRepository.Save(Complemento);
        }
    }
}
