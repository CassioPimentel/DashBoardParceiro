using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardParceiro.Repository.Cadastros.ObservacaoFolder
{
    public class ObservacaoRepository : IObservacaoRepository
    {
        private Context _context;
        public ObservacaoRepository(Context context)
        {
            _context = context;
        }

        public List<Observacao> GetAll()
        {
            return _context.Observacao.ToList();
        }

        public Observacao Save(Observacao observacao)
        {
            try
            {
                if (observacao.Codigo == 0)
                {
                    _context.Entry(observacao).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(observacao).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return observacao;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int Excluir(int Id)
        {
            try
            {
                var observacao = Get(Id);
                _context.Remove(observacao);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Observacao Get(int Id)
        {
            return _context.Observacao.Find(Id);
        }
    }
}
