using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;

namespace DashboardParceiro.Repository.Cadastros.ParceiroFolder
{
    public class ParceiroRepository : IParceiroRepository
    {
        private Context _context;
        public ParceiroRepository(Context context)
        {
            _context = context;
        }

        public ParceiroModel Get(int Id)
        {
            return _context.Parceiro.Find(Id);
        }

        public ParceiroModel Save(ParceiroModel Parceiro)
        {
            try
            {
                if (Parceiro.Id == 0)
                {
                    _context.Entry(Parceiro).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(Parceiro).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return Parceiro;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
