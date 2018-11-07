using DashboardParceiro.Models.Cadastros;

namespace DashboardParceiro.Service.Cadastros.ParceiroFolder
{
    public interface IParceiroService
    {
        ParceiroModel Get(int Id);
        ParceiroModel Save(ParceiroModel Parceiro);
    }
}
