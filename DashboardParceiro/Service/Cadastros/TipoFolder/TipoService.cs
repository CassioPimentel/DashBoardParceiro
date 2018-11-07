using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Repository.Cadastros.TipoFolder;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.TipoFolder
{
    public class TipoService : ITipoService
    {
        private ITipoRepository _tipoRepository;

        public TipoService(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

        public int Excluir(int Id)
        {
            return _tipoRepository.Excluir(Id);
        }

        public Tipo Get(int Id)
        {
            return _tipoRepository.Get(Id);
        }

        public List<Tipo> GetAll()
        {
            return _tipoRepository.GetAll();
        }

        public Tipo Save(Tipo Tipo)
        {
            return _tipoRepository.Save(Tipo);
        }
    }
}
