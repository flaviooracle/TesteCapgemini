using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public virtual DbSet<Tabela1> Tabela1 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity<Tabela1>( b =>
            {
                b.Property<int>("Tabela1Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("DataEntrega")
                    .HasColumnType("datetime2");

                b.Property<string>("NomeProduto")
                    .IsRequired()
                    .HasColumnName("NomeProduto")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                b.Property<int>("Quantidade")
                    .HasColumnType("int");

                b.Property<double>("ValorUnitario")
                    .HasColumnType("float");

                b.HasKey("Tabela1Id");

                b.ToTable("Tabela1");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Password=123;Persist Security Info=True;User ID=sa;Initial Catalog=Capgemini;Data Source=DESKTOP-EUD6FT9\\SQLEXPRESS");
            }
        }
    }
}
