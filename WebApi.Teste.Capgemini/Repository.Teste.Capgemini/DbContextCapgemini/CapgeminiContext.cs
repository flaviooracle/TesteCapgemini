using Microsoft.EntityFrameworkCore;
using Repository.Teste.Capgemini.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Teste.Capgemini.DbContextCapgemini
{
    public class CapgeminiContext : DbContext
    {
        public CapgeminiContext(DbContextOptions<CapgeminiContext> opcoes) : base(opcoes)
        { }
        public DbSet<Tabela1> Tabela1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Password=123;Persist Security Info=True;User ID=sa;Initial Catalog=Capgemini;Data Source=DESKTOP-EUD6FT9\\SQLEXPRESS");
            }
        }
    }
}
