using Microsoft.EntityFrameworkCore;
using PetshopMiau.Core;
using System;
using System.IO;

namespace PetshopMiau.Data
{
    public class PetshopContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<ClientePacote> ClientesPacotes { get; set; }

        public DbSet<MovimentacaoCaixa> MovimentacoesCaixa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string basePath = AppContext.BaseDirectory;
            string dbPath = Path.Combine(basePath, "petshop.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}