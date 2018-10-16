using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
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
                _context.Categoria.Add(categoria);
                _context.SaveChanges();

                return categoria;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
