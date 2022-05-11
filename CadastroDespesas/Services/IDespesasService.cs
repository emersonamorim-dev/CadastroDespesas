using CadastroDespesas.Models.Despesas;

namespace CadastroDespesas.Services
{
    public interface IDespesasService
    {
        Task Create(DTOs.CreateDespesasDTO createDespesasDTOs);

        Task<List<Despesas>> FindBy(DateTime startDate, DateTime endDate);
    }
}
