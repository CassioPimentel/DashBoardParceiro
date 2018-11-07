using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Models.Cadastros.ModelBinding;
using DashboardParceiro.Repository.Cadastros.ComplCategoriaFolder;
using System;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.TamanhoTipoFolder
{
    public class TamanhoTipoService : ITamanhoTipoService
    {
        private IComplementoCategoriaRepository _complementoCategoriaRepository;

        public TamanhoTipoService(IComplementoCategoriaRepository complementoCategoriaRepository)
        {
            _complementoCategoriaRepository = complementoCategoriaRepository;
        }

        public List<ComplementoCategoria> GetCategoriaVinculado(int CodigoComplemento)
        {
            return _complementoCategoriaRepository.GetCategoriaVinculado(CodigoComplemento);
        }

        public List<ComplementoCategoria> GetCategorias(int CodigoCategoria)
        {
            return _complementoCategoriaRepository.GetCategorias(CodigoCategoria);
        }

        public string Save(ComplementoCategoriaBind Model)
        {
            return _complementoCategoriaRepository.Save(Model);
        }

        public void Excluir(int CodigoComplemento)
        {
            _complementoCategoriaRepository.Excluir(CodigoComplemento);
        }
    }
}
