using CadastroDespesas.Models.Despesas;

namespace CadastroDespesas.DTOs
{
    public class ListDespesasDTO
    {
        public ListDespesasDTO()
        {
            StartDate = DateTime.UtcNow.AddDays(-7);
            EndDate = DateTime.UtcNow.AddDays(3);
            Items = new List<Despesas>();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
         public List<Despesas> Items { get; set; }
    }
}
