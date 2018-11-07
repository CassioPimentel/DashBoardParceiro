using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardParceiro.Repository.Cadastros.TamanhoFolder
{
    public class TamanhoRepository : ITamanhoRepository
    {
        private Context _context;
        public TamanhoRepository(Context context)
        {
            _context = context;
        }

        public int Excluir(int Id)
        {
            try
            {
                var Tamanho = Get(Id);
                _context.Remove(Tamanho);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Tamanho Get(int Id)
        {
            return _context.Tamanho.Find(Id);
        }

        public List<Tamanho> GetAll()
        {
            return _context.Tamanho.ToList();
        }

        public Tamanho Save(Tamanho Tamanho)
        {
            try
            {
                if (Tamanho.Codigo == 0)
                {
                    _context.Entry(Tamanho).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(Tamanho).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return Tamanho;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}