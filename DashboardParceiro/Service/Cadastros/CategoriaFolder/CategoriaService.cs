﻿using System.Collections.Generic;
using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Repository.Cadastros.CategoriaFolder;

namespace DashboardParceiro.Service.Cadastros.CategoriaFolder
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<Categoria> GetAll()
        {
            return _categoriaRepository.GetAll();
        }

        public Categoria Save(Categoria categoria)
        {
            return _categoriaRepository.Save(categoria);
        }

        public int Excluir(int Id)
        {
            return _categoriaRepository.Excluir(Id);
        }

        public Categoria Get(int Id)
        {
            return _categoriaRepository.Get(Id);
        }

        public List<Categoria> GetCategorias(int[] Ids)
        {
            return _categoriaRepository.GetCategorias(Ids);
        }
    }
}
