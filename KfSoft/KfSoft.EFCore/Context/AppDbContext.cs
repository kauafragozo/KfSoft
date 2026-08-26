using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KfSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace KfSoft.EFCore.Context
{
    public  class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.DataCriacao)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.HasData(
                    new Departamento {Codigo = 1, Nome = "Departamento de TI", Descricao = "Departamento de Tecnologia da Informação" },
                    new Departamento {Codigo = 2, Nome = "Departamento de RH", Descricao = "Departamento de Recursos Humanos" }
                    );

            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Responsavel)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.DataInicio)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Status)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("1");

                entity.HasData(
                    new Projeto { Codigo = 1, Descricao = "Desenvolvimento de Sistema de Gestão", Responsavel = "Kauã Fragozo", Status = false },
                    new Projeto{Codigo = 2, Descricao="Melhorias no Banco de Dados da Empresa'", Responsavel = "Kauã Fragozo", Status = true}
                   );
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Cargo)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.DataAdimissao)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Salario)
                .HasColumnType("decimal(10,2)");

                //entity.HasData(
                //    new Funcionario { Codigo = 1, Nome = "Kauã Fragozo", Cargo = "Desenvolvedor", DepartamentoCodigo = 1 }

                //    );
            });

        }


    }
}
