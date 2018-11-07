using DashboardParceiro.Models.Cadastros;

namespace DashboardParceiro.Repository.Cadastros.ParceiroFolder
{
    public interface IParceiroRepository
    {
        ParceiroModel Get(int Id);
        ParceiroModel Save(ParceiroModel Parceiro);
    }
}
