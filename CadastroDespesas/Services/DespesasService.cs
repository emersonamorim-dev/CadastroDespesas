using CadastroDespesas.Infra.Database;
using CadastroDespesas.Models.Despesas;
using Microsoft.EntityFrameworkCore;


namespace CadastroDespesas.Services
{
    public class DespesasService : IDespesasService
    {
        private readonly DespesasControlContext _dbContext;

        public DespesasService(DespesasControlContext context)
        {
            _dbContext = context;
        }
        public async Task Create(DTOs.CreateDespesasDTO createDespesasDTOs)
        {
            await _dbContext.Despesas.AddAsync(new Despesas()
            {
                Descricao = createDespesasDTOs.Descricao,
                Date = createDespesasDTOs.Date,
                Value = createDespesasDTOs.Value
            });
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Despesas>> FindBy(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new Exception("Data final deve maior que data inicial");

            var items = await _dbContext.Despesas.Where(e => e.Date >= startDate && e.Date <= endDate).AsNoTracking()
                .ToListAsync();

            return items;
        }

    }
}
