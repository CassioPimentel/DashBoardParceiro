using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardParceiro.Repository.Cadastros.ComplementoFolder
{
    public class ComplementoRepository : IComplementoRepository
    {
        private Context _context;
        public ComplementoRepository(Context context)
        {
            _context = context;
        }

        public int Excluir(int Id)
        {
            try
            {
                var Complemento = Get(Id);
                _context.Remove(Complemento);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Complemento Get(int Id)
        {
            return _context.Complemento.Find(Id);
        }

        public List<Complemento> GetAll()
        {
            return _context.Complemento.ToList();
        }

        public Complemento Save(Complemento Complemento)
        {
            try
            {
                if (Complemento.Codigo == 0)
                {
                    _context.Entry(Complemento).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(Complemento).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return Complemento;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}