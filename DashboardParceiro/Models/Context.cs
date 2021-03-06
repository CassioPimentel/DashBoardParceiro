﻿using DashboardParceiro.Models.Cadastros;
using Microsoft.EntityFrameworkCore;

namespace DashboardParceiro.Models
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=db4free.net;Database=dashboardparceir;Uid=cassiowin98;Pwd=eng1211048");
            }
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Observacao> Observacao { get; set; }
        public DbSet<Tamanho> Tamanho { get; set; }
        public DbSet<ParceiroModel> Parceiro { get; set; }
        public DbSet<Complemento> Complemento { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Medida> Medida { get; set; }
        public DbSet<ComplementoCategoria> ComplementoCategoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}