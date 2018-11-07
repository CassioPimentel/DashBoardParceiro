using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Service.Cadastros.TamanhoFolder
{
    public interface ITamanhoService
    {
        List<Tamanho> GetAll();
        Tamanho Get(int Id);
        Tamanho Save(Tamanho Tamanho);
        int Excluir(int Id);
    }
}
