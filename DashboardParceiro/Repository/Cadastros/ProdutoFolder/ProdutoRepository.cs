using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardParceiro.Repository.Cadastros.ProdutoFolder
{
    public class ProdutoRepository : IProdutoRepository
    {
        private Context _context;
        public ProdutoRepository(Context context)
        {
            _context = context;
        }

        public int Excluir(int Id)
        {
            try
            {
                var Produto = Get(Id);
                _context.Remove(Produto);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Produto Get(int Id)
        {
            return _context.Produto.Find(Id);
        }

        public List<Produto> GetAll()
        {
            try
            {
                return _context.Produto.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }          
        }

        public Produto Save(Produto Produto)
        {
            try
            {
                if (Produto.Codigo == 0)
                {
                    _context.Entry(Produto).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(Produto).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return Produto;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}