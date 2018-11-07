using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardParceiro.Repository.Cadastros.CategoriaFolder
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private Context _context;
        public CategoriaRepository(Context context)
        {
            _context = context;
        }

        public List<Categoria> GetAll()
        {
            return _context.Categoria.ToList();
        }

        public Categoria Save(Categoria categoria)
        {
            try
            {
                if (categoria.Codigo == 0)
                {
                    _context.Entry(categoria).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(categoria).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return categoria;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int Excluir(int Id)
        {
            try
            {
                var categoria = Get(Id);
                _context.Remove(categoria);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Categoria Get(int Id)
        {
            return _context.Categoria.Find(Id);
        }

        public List<Categoria> GetCategorias(int[] Ids)
        {
            try
            {
                return _context.Categoria.Where(x => Ids.Contains(x.Codigo)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
