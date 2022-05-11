using CadastroDespesas.Models.Despesas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDespesas.Infra.Database
{
    public class DespesasControlContext : DbContext
    {
        public DbSet<Despesas> Despesas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=DespesasControl.db");
    }
}
