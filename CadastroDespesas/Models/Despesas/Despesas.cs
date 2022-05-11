using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDespesas.Models.Despesas
{
    public class Despesas
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Descricao{ get; set; }

        public double Value { get; set; }

        public DateTime Date { get; set; }
    }
}
