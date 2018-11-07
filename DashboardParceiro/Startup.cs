using DashboardParceiro.Models;
using DashboardParceiro.Repository.Cadastros.CategoriaFolder;
using DashboardParceiro.Repository.Cadastros.ComplCategoriaFolder;
using DashboardParceiro.Repository.Cadastros.ComplementoFolder;
using DashboardParceiro.Repository.Cadastros.ObservacaoFolder;
using DashboardParceiro.Repository.Cadastros.ParceiroFolder;
using DashboardParceiro.Repository.Cadastros.TipoFolder;
using DashboardParceiro.Service.Cadastros.CategoriaFolder;
using DashboardParceiro.Service.Cadastros.ComplCategoriaFolder;
using DashboardParceiro.Service.Cadastros.ComplementoFolder;
using DashboardParceiro.Service.Cadastros.ObservacaoFolder;
using DashboardParceiro.Service.Cadastros.ParceiroFolder;
using DashboardParceiro.Service.Cadastros.TipoFolder;
using DashboardParceiro.Service.Cadastros.ComplementoFolder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DashboardParceiro.Repository.Cadastros.TamanhoFolder;
using DashboardParceiro.Service.Cadastros.TamanhoFolder;

namespace DashboardParceiro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConnectionStrings:ParceiroDatabase"];
            services.AddDbContext<Context>(options => options.UseMySql(connection));

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<IObservacaoRepository, ObservacaoRepository>();
            services.AddScoped<IObservacaoService, ObservacaoService>();

            services.AddScoped<IParceiroRepository, ParceiroRepository>();
            services.AddScoped<IParceiroService, ParceiroService>();

            services.AddScoped<IComplementoRepository, ComplementoRepository>();
            services.AddScoped<IComplementoService, ComplementoService>();

            services.AddScoped<IComplementoCategoriaRepository, ComplementoCategoriaRepository>();
            services.AddScoped<IComplementoCategoriaService, ComplementoCategoriaService>();

            services.AddScoped<ITipoRepository, TipoRepository>();
            services.AddScoped<ITipoService, TipoService>();

            services.AddScoped<ITamanhoRepository, TamanhoRepository>();
            services.AddScoped<ITamanhoService, TamanhoService>();

            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}