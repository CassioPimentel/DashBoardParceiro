using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Models.Cadastros.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardParceiro.Repository.Cadastros.TamanhoTipoFolder
{
    public class TamanhoTipoRepository : ITamanhoTipoRepository
    {
        private Context _context;
        public TamanhoTipoRepository(Context context)
        {
            _context = context;
        }

        public List<ComplementoCategoria> GetCategorias(int CodigoCategoria)
        {
            try
            {
                return _context.ComplementoCategoria.Where(x => x.CodigoCategoria == CodigoCategoria).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ComplementoCategoria> GetCategoriaVinculado(int CodigoComplemento)
        {
            try
            {
                return _context.ComplementoCategoria.Where(x => x.CodigoComplemento == CodigoComplemento).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Save(ComplementoCategoriaBind Model)
        {
            try
            {
                Excluir(Model.Complemento.Codigo);

                foreach (var item in Model.CategoriaIds)
                {
                    var ComplementoCategoria = new ComplementoCategoria();

                    ComplementoCategoria.CodigoCategoria = item;
                    ComplementoCategoria.CodigoComplemento = Model.Complemento.Codigo;
                    ComplementoCategoria.CodigoParceiro = 3;

                    _context.Entry(ComplementoCategoria).State = EntityState.Added;
                    _context.SaveChanges();
                }

                return "Sucesso";
            }
            catch (Exception ex)
            {
                return "Erro";
            }
        }

        public int Excluir(int CodigoComplemento)
        {
            try
            {
                var ListaCategoria = _context.ComplementoCategoria.Where(x => x.CodigoComplemento == CodigoComplemento).ToList();

                foreach (var item in ListaCategoria)
                {
                    var ComplementoCategoria = _context.ComplementoCategoria.Where(x => x.CodigoCategoria == item.CodigoCategoria && 
                                                                                        x.CodigoComplemento == CodigoComplemento).FirstOrDefault();

                    if (ComplementoCategoria != null)
                    {
                        _context.Remove(ComplementoCategoria);
                    }   
                }

                _context.SaveChanges();

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}