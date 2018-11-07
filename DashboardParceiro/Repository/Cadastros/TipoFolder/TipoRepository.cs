using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardParceiro.Repository.Cadastros.TipoFolder
{
    public class TipoRepository : ITipoRepository
    {
        private Context _context;
        public TipoRepository(Context context)
        {
            _context = context;
        }

        public int Excluir(int Id)
        {
            try
            {
                var Tipo = Get(Id);
                _context.Remove(Tipo);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Tipo Get(int Id)
        {
            return _context.Tipo.Find(Id);
        }

        public List<Tipo> GetAll()
        {
            return _context.Tipo.ToList();
        }

        public Tipo Save(Tipo Tipo)
        {
            try
            {
                if (Tipo.Codigo == 0)
                {
                    _context.Entry(Tipo).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(Tipo).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return Tipo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}