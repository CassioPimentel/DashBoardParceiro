using DashboardParceiro.Models.Cadastros;
using System.Collections.Generic;

namespace DashboardParceiro.Repository.Cadastros.TamanhoFolder
{
    public interface ITamanhoRepository
    {
        List<Tamanho> GetAll();
        Tamanho Get(int Id);
        Tamanho Save(Tamanho Tamanho);
        int Excluir(int Id);
    }
}
