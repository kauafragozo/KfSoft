using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KfSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace KfSoft.EFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioDetalhe> FuncionarioDetalhes { get; set; }

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
                .HasMaxLength(100);

                entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.DataCriacao)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.HasData(
                    new Departamento { Codigo = 1, Nome = "Departamento de TI", Descricao = "Departamento de Tecnologia da Informação" },
                    new Departamento { Codigo = 2, Nome = "Departamento de RH", Descricao = "Departamento de Recursos Humanos" }
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

                entity.HasData(
                    new Funcionario { Codigo = 1, Nome = "Kauã Fragozo", Cargo = "Desenvolvedor", DepartamentoCodigo = 1 }

                    );
            });

            modelBuilder.Entity<FuncionarioDetalhe>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.EnderecoResidencial)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.DataNascimento)
                .IsRequired();
                entity.Property(e => e.Celular)
                .IsRequired()
                .HasMaxLength(20);
                entity.Property(e => e.Genero)
                .IsRequired()
                .HasMaxLength(10);
                entity.Property(e => e.EstadoCivil)
                .IsRequired()
                .HasMaxLength(20);
                entity.Property(e => e.CPF)
                .IsRequired()
                .HasMaxLength(14);
                entity.Property(e => e.Nacionalidade)
                .IsRequired()
                .HasMaxLength(20);
                entity.Property(e => e.Escolaridade)
                .IsRequired()
                .HasMaxLength(40);

                entity.HasData(
                    new FuncionarioDetalhe {Codigo = 1, EnderecoResidencial = "Rua da Paz", DataNascimento = new DateOnly (2003, 11, 24), Celular = "40002-8922", Genero = "Masculino", EstadoCivil = "Solteiro", CPF = "000.000.000-00", Nacionalidade = "Brasileiro", Escolaridade = "Superior em Andamento", FuncionarioCodigo = 1 }
                );

            });


        }


    }
}
