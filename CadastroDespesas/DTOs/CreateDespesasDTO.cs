using System.ComponentModel.DataAnnotations;

namespace CadastroDespesas.DTOs
{
    public class CreateDespesasDTO
    {
        public CreateDespesasDTO()
        {
            Date = DateTime.Now;    
        }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(0.01, 99999999999, ErrorMessage = "Valor deve ser maior que 0")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Data é obrigatório")]
        public DateTime Date { get; set; }
    }
}
