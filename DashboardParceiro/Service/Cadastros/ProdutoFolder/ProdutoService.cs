using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Repository.Cadastros.ProdutoFolder;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.ProdutoFolder
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public int Excluir(int Id)
        {
            return _produtoRepository.Excluir(Id);
        }

        public Produto Get(int Id)
        {
            return _produtoRepository.Get(Id);
        }

        public List<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        public Produto Save(Produto Tamanho)
        {
            return _produtoRepository.Save(Tamanho);
        }
    }
}