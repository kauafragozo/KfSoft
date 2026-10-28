using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KfSoft.Entities;
using Microsoft.EntityFrameworkCore;
namespace KfSoft.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioDetalhe> FuncionarioDetalhes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<ProjetoFuncionario> ProjetoFuncionario { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

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
                     new Departamento { Codigo = 1, Nome = "Financeiro", Descricao = "Gestão das finanças" },
                  new Departamento { Codigo = 2, Nome = "Marketing", Descricao = "Promoção de produtos" },
                  new Departamento { Codigo = 3, Nome = "RH", Descricao = "Recursos Humanos" },
                  new Departamento { Codigo = 4, Nome = "Suporte", Descricao = "Atendimento ao cliente" },
                  new Departamento { Codigo = 5, Nome = "TI", Descricao = "Tecnologia da Informação" },
                  new Departamento { Codigo = 6, Nome = "Vendas", Descricao = "Gestão de Vendas" }
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

                entity.Property(e => e.DataContratacao)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Salario)
                .HasColumnType("decimal(10,2)");

                entity.HasData(
                    //Finanças
                    new Funcionario { Codigo = 1, Nome = "João Silva", Cargo = "Gerente de Finanças", Salario = 5250.00m, DataContratacao = new DateOnly(2023, 1, 15), DepartamentoCodigo = 1 },
               new Funcionario { Codigo = 2, Nome = "Carlos Pereira", Cargo = "Analista Financeiro", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoCodigo = 1 },
               new Funcionario { Codigo = 3, Nome = "Ana Souza", Cargo = "Analista Contábil", Salario = 4300.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoCodigo = 1 },
               new Funcionario { Codigo = 4, Nome = "Marcos Lima", Cargo = "Assistente Financeiro", Salario = 3200.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoCodigo = 1 },
               new Funcionario { Codigo = 5, Nome = "Fernanda Oliveira", Cargo = "Coordenadora Financeira", Salario = 4800.00m, DataContratacao = new DateOnly(2023, 4, 5), DepartamentoCodigo = 1 },
               new Funcionario { Codigo = 6, Nome = "José Santos", Cargo = "Técnico em Contabilidade", Salario = 3400.00m, DataContratacao = new DateOnly(2023, 7, 18), DepartamentoCodigo = 1 },
               // Marketing
               new Funcionario { Codigo = 7, Nome = "Lucia Benitez", Cargo = "Coordenador de Marketing", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoCodigo = 2 },
               new Funcionario { Codigo = 8, Nome = "Pedro Cardoso", Cargo = "Analista de Marketing", Salario = 4100.00m, DataContratacao = new DateOnly(2022, 8, 22), DepartamentoCodigo = 2 },
               new Funcionario { Codigo = 9, Nome = "Carla Teixeira", Cargo = "Especialista em SEO", Salario = 3900.00m, DataContratacao = new DateOnly(2022, 10, 15), DepartamentoCodigo = 2 },
               new Funcionario { Codigo = 10, Nome = "Fabiana Costa", Cargo = "Gerente de Marketing", Salario = 5100.00m, DataContratacao = new DateOnly(2023, 3, 1), DepartamentoCodigo = 2 },
               //RH
               new Funcionario { Codigo = 11, Nome = "Roberto Ferreira", Cargo = "Analista de Recursos Humanos", Salario = 4400.00m, DataContratacao = new DateOnly(2021, 9, 20), DepartamentoCodigo = 3 },
               new Funcionario { Codigo = 12, Nome = "Beatriz Almeida", Cargo = "Gerente de Recursos Humanos", Salario = 5000.00m, DataContratacao = new DateOnly(2022, 3, 10), DepartamentoCodigo = 3 },
               new Funcionario { Codigo = 13, Nome = "Lucas Santos", Cargo = "Coordenador de Recursos Humanos", Salario = 4600.00m, DataContratacao = new DateOnly(2022, 7, 15), DepartamentoCodigo = 3 },
               new Funcionario { Codigo = 14, Nome = "Mariana Dias", Cargo = "Assistente de Recursos Humanos", Salario = 3200.00m, DataContratacao = new DateOnly(2023, 5, 5), DepartamentoCodigo = 3 },
               //Suporte
               new Funcionario { Codigo = 15, Nome = "Juliana Mendes", Cargo = "Analista de Suporte", Salario = 3600.00m, DataContratacao = new DateOnly(2022, 6, 15), DepartamentoCodigo = 4 },
               new Funcionario { Codigo = 16, Nome = "Rafael Souza", Cargo = "Técnico de Suporte", Salario = 3400.00m, DataContratacao = new DateOnly(2022, 8, 22), DepartamentoCodigo = 4 },
               new Funcionario { Codigo = 17, Nome = "André Oliveira", Cargo = "Especialista em Suporte", Salario = 3800.00m, DataContratacao = new DateOnly(2022, 10, 15), DepartamentoCodigo = 4 },
               new Funcionario { Codigo = 18, Nome = "Bruno Costa", Cargo = "Coordenador de Suporte", Salario = 4000.00m, DataContratacao = new DateOnly(2023, 1, 1), DepartamentoCodigo = 4 },
               new Funcionario { Codigo = 19, Nome = "Aline Dias", Cargo = "Assistente de Suporte", Salario = 3200.00m, DataContratacao = new DateOnly(2023, 3, 10), DepartamentoCodigo = 4 },
               //TI
               new Funcionario { Codigo = 20, Nome = "Fernando Carvalho", Cargo = "Analista de TI", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoCodigo = 5 },
               new Funcionario { Codigo = 21, Nome = "Gustavo Almeida", Cargo = "Desenvolvedor de Sistemas", Salario = 5000.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoCodigo = 5 },
               new Funcionario { Codigo = 22, Nome = "Renata Silva", Cargo = "Coordenadora de TI", Salario = 4800.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoCodigo = 5 },
               new Funcionario { Codigo = 23, Nome = "Thiago Souza", Cargo = "Técnico de Redes", Salario = 3600.00m, DataContratacao = new DateOnly(2023, 4, 5), DepartamentoCodigo = 5 },
               new Funcionario { Codigo = 24, Nome = "Vanessa Oliveira", Cargo = "Engenheira de Software", Salario = 5200.00m, DataContratacao = new DateOnly(2023, 7, 18), DepartamentoCodigo = 5 },
               new Funcionario { Codigo = 25, Nome = "Leonardo Pereira", Cargo = "Especialista em Segurança da Informação", Salario = 5500.00m, DataContratacao = new DateOnly(2023, 8, 1), DepartamentoCodigo = 5 },
               //Vendas
               new Funcionario { Codigo = 26, Nome = "Marta Carvalho", Cargo = "Gerente de Vendas", Salario = 5200.00m, DataContratacao = new DateOnly(2021, 10, 10), DepartamentoCodigo = 6 },
               new Funcionario { Codigo = 27, Nome = "Ricardo Pereira", Cargo = "Representante de Vendas", Salario = 4500.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoCodigo = 6 },
               new Funcionario { Codigo = 28, Nome = "Patrícia Santos", Cargo = "Assistente de Vendas", Salario = 3200.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoCodigo = 6 },
               new Funcionario { Codigo = 29, Nome = "Alberto Lima", Cargo = "Coordenador de Vendas", Salario = 4800.00m, DataContratacao = new DateOnly(2022, 7, 18), DepartamentoCodigo = 6 },
               new Funcionario { Codigo = 30, Nome = "Bianca Souza", Cargo = "Especialista em Vendas", Salario = 5000.00m, DataContratacao = new DateOnly(2023, 3, 5), DepartamentoCodigo = 6 },
               new Funcionario { Codigo = 31, Nome = "Rogério Oliveira", Cargo = "Consultor de Vendas", Salario = 4700.00m, DataContratacao = new DateOnly(2023, 6, 10), DepartamentoCodigo = 6 },
               new Funcionario { Codigo = 32, Nome = "Sofia Almeida", Cargo = "Técnico de Vendas", Salario = 3400.00m, DataContratacao = new DateOnly(2023, 9, 1), DepartamentoCodigo = 6 }

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
                    new FuncionarioDetalhe { Codigo = 1, FuncionarioCodigo = 1, EnderecoResidencial = "Rua A, 123", DataNascimento = new DateTime(1990, 5, 10), Celular = "999999999", Genero = Genero.Masculino, Foto = "foto1.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "12345678901", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
     new FuncionarioDetalhe { Codigo = 2, FuncionarioCodigo = 2, EnderecoResidencial = "Rua B, 234", DataNascimento = new DateTime(1988, 11, 20), Celular = "988888888", Genero = Genero.Masculino, Foto = "foto2.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "23456789012", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 3, FuncionarioCodigo = 3, EnderecoResidencial = "Rua C, 345", DataNascimento = new DateTime(1992, 8, 15), Celular = "977777777", Genero = Genero.Feminino, Foto = "foto3.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "34567890123", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
     new FuncionarioDetalhe { Codigo = 4, FuncionarioCodigo = 4, EnderecoResidencial = "Rua D, 456", DataNascimento = new DateTime(1985, 2, 25), Celular = "966666666", Genero = Genero.Masculino, Foto = "foto4.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "45678901234", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
     new FuncionarioDetalhe { Codigo = 5, FuncionarioCodigo = 5, EnderecoResidencial = "Rua E, 567", DataNascimento = new DateTime(1994, 3, 5), Celular = "955555555", Genero = Genero.Feminino, Foto = "foto5.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "56789012345", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 6, FuncionarioCodigo = 6, EnderecoResidencial = "Rua F, 678", DataNascimento = new DateTime(1989, 12, 15), Celular = "944444444", Genero = Genero.Masculino, Foto = "foto6.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "67890123456", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },

     new FuncionarioDetalhe { Codigo = 7, FuncionarioCodigo = 7, EnderecoResidencial = "Rua G, 789", DataNascimento = new DateTime(1991, 7, 21), Celular = "933333333", Genero = Genero.Feminino, Foto = "foto7.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "78901234567", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 8, FuncionarioCodigo = 8, EnderecoResidencial = "Rua H, 890", DataNascimento = new DateTime(1986, 4, 14), Celular = "922222222", Genero = Genero.Masculino, Foto = "foto8.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "89012345678", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
     new FuncionarioDetalhe { Codigo = 9, FuncionarioCodigo = 9, EnderecoResidencial = "Rua I, 901", DataNascimento = new DateTime(1993, 9, 12), Celular = "911111111", Genero = Genero.Feminino, Foto = "foto9.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "90123456789", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
     new FuncionarioDetalhe { Codigo = 10, FuncionarioCodigo = 10, EnderecoResidencial = "Rua J, 101", DataNascimento = new DateTime(1995, 11, 18), Celular = "900000000", Genero = Genero.Masculino, Foto = "foto10.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "01234567890", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },

     new FuncionarioDetalhe { Codigo = 11, FuncionarioCodigo = 11, EnderecoResidencial = "Rua K, 111", DataNascimento = new DateTime(1987, 1, 22), Celular = "988888888", Genero = Genero.Feminino, Foto = "foto11.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11111111111", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
     new FuncionarioDetalhe { Codigo = 12, FuncionarioCodigo = 12, EnderecoResidencial = "Rua L, 121", DataNascimento = new DateTime(1990, 2, 2), Celular = "977777777", Genero = Genero.Masculino, Foto = "foto12.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22222222222", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
     new FuncionarioDetalhe { Codigo = 13, FuncionarioCodigo = 13, EnderecoResidencial = "Rua M, 131", DataNascimento = new DateTime(1991, 3, 3), Celular = "966666666", Genero = Genero.Feminino, Foto = "foto13.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33333333333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 14, FuncionarioCodigo = 14, EnderecoResidencial = "Rua N, 141", DataNascimento = new DateTime(1992, 4, 4), Celular = "955555555", Genero = Genero.Masculino, Foto = "foto14.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "44444444444", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
     new FuncionarioDetalhe { Codigo = 15, FuncionarioCodigo = 15, EnderecoResidencial = "Rua O, 151", DataNascimento = new DateTime(1993, 5, 5), Celular = "944444444", Genero = Genero.Feminino, Foto = "foto15.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55555555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 16, FuncionarioCodigo = 16, EnderecoResidencial = "Rua P, 161", DataNascimento = new DateTime(1994, 6, 6), Celular = "933333333", Genero = Genero.Masculino, Foto = "foto16.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "66666666666", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
     new FuncionarioDetalhe { Codigo = 17, FuncionarioCodigo = 17, EnderecoResidencial = "Rua Q, 171", DataNascimento = new DateTime(1995, 7, 7), Celular = "922222222", Genero = Genero.Feminino, Foto = "foto17.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "77777777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 18, FuncionarioCodigo = 18, EnderecoResidencial = "Rua R, 181", DataNascimento = new DateTime(1996, 8, 8), Celular = "911111111", Genero = Genero.Masculino, Foto = "foto18.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88888888888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
     new FuncionarioDetalhe { Codigo = 19, FuncionarioCodigo = 19, EnderecoResidencial = "Rua S, 191", DataNascimento = new DateTime(1997, 9, 9), Celular = "900000000", Genero = Genero.Feminino, Foto = "foto19.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99999999999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
     new FuncionarioDetalhe { Codigo = 20, FuncionarioCodigo = 20, EnderecoResidencial = "Rua T, 201", DataNascimento = new DateTime(1988, 10, 10), Celular = "988888888", Genero = Genero.Masculino, Foto = "foto20.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "00000000000", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },

     new FuncionarioDetalhe { Codigo = 21, FuncionarioCodigo = 21, EnderecoResidencial = "Rua U, 211", DataNascimento = new DateTime(1989, 11, 11), Celular = "977777777", Genero = Genero.Feminino, Foto = "foto21.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11112222222", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
     new FuncionarioDetalhe { Codigo = 22, FuncionarioCodigo = 22, EnderecoResidencial = "Rua V, 221", DataNascimento = new DateTime(1990, 12, 12), Celular = "966666666", Genero = Genero.Masculino, Foto = "foto22.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22223333333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
     new FuncionarioDetalhe { Codigo = 23, FuncionarioCodigo = 23, EnderecoResidencial = "Rua W, 231", DataNascimento = new DateTime(1991, 1, 13), Celular = "955555555", Genero = Genero.Feminino, Foto = "foto23.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33334444444", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 24, FuncionarioCodigo = 24, EnderecoResidencial = "Rua X, 241", DataNascimento = new DateTime(1992, 2, 14), Celular = "944444444", Genero = Genero.Masculino, Foto = "foto24.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "44445555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
     new FuncionarioDetalhe { Codigo = 25, FuncionarioCodigo = 25, EnderecoResidencial = "Rua Y, 251", DataNascimento = new DateTime(1993, 3, 15), Celular = "933333333", Genero = Genero.Feminino, Foto = "foto25.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55556666666", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 26, FuncionarioCodigo = 26, EnderecoResidencial = "Rua Z, 261", DataNascimento = new DateTime(1994, 4, 16), Celular = "922222222", Genero = Genero.Masculino, Foto = "foto26.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "66667777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
     new FuncionarioDetalhe { Codigo = 27, FuncionarioCodigo = 27, EnderecoResidencial = "Rua AA, 271", DataNascimento = new DateTime(1995, 5, 17), Celular = "911111111", Genero = Genero.Feminino, Foto = "foto27.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "77778888888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 28, FuncionarioCodigo = 28, EnderecoResidencial = "Rua AB, 281", DataNascimento = new DateTime(1996, 6, 18), Celular = "900000000", Genero = Genero.Masculino, Foto = "foto28.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88889999999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },

     new FuncionarioDetalhe { Codigo = 29, FuncionarioCodigo = 29, EnderecoResidencial = "Rua AC, 291", DataNascimento = new DateTime(1997, 7, 19), Celular = "988888888", Genero = Genero.Feminino, Foto = "foto29.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99990000000", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
     new FuncionarioDetalhe { Codigo = 30, FuncionarioCodigo = 30, EnderecoResidencial = "Rua AD, 291", DataNascimento = new DateTime(1998, 7, 19), Celular = "988778888", Genero = Genero.Feminino, Foto = "foto30.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99990000002", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 31, FuncionarioCodigo = 31, EnderecoResidencial = "Rua AJ, 291", DataNascimento = new DateTime(1998, 11, 9), Celular = "988778866", Genero = Genero.Feminino, Foto = "foto30.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "99990000001", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
     new FuncionarioDetalhe { Codigo = 32, FuncionarioCodigo = 32, EnderecoResidencial = "Rua AD, 301", DataNascimento = new DateTime(1988, 8, 20), Celular = "977777777", Genero = Genero.Masculino, Foto = "foto30.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "00001111111", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio });
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e => e.Descricao)
                .HasMaxLength(100);
                entity.Property(e => e.Orcamento)
                .HasPrecision(10, 2);
                entity.Property(e => e.DataInicio)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE ()");
                entity.Property(e => e.DataAtualizacao)
                .ValueGeneratedOnUpdate();
                entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValue(StatusProjeto.EmAprovacao);

                entity.HasData(
                   new Projeto { Codigo = 1, Nome = "KfSoft", Descricao = "Desenvolvimento de Sistema de Gestao de Projetos", Orcamento = 100.00m, Status = StatusProjeto.Iniciado, ClienteCodigo = 5 },
                   new Projeto { Codigo = 2, Nome = "ImcManager", Descricao = "Calculadora de IMC, Cadastro de Pacientes e Relatorios", Orcamento = 150.00m, Status = StatusProjeto.Concluido, ClienteCodigo = 3},
                   new Projeto { Codigo = 3, Nome = "Catalogo de Filmes", Descricao = "Banco de Dados para Sistema de Filmes", Orcamento = 200.00m, Status = StatusProjeto.Concluido, ClienteCodigo = 5}
                   );

            });

            modelBuilder.Entity<ProjetoFuncionario>()
            .HasKey(fp => new { fp.FuncionarioCodigo, fp.ProjetoCodigo });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(75);
                entity.Property(e => e.Telefone)
                .IsRequired()
                .HasMaxLength(20);

                entity.HasData(
                    new Cliente { Codigo = 1, Nome = "Grupo Plast SA", Email = "plastsa@plastsa.com.br", Telefone = "54 998876655" },
                    new Cliente { Codigo = 2, Nome = "Caua e Cesar Mudanças Ltda", Email = "qualidade@cauaecesarmudancasltda.com.br", Telefone = "(12) 2872-7157" },
                    new Cliente { Codigo = 3, Nome = "Bento e Francisco Medicina Geral", Email = "cobranca@bentoefranciscomedicina.com.br", Telefone = "(13) 3756-5745" },
                    new Cliente { Codigo = 4, Nome = "Luciana e Stefany Advocacia ME", Email = "vendas@lucianaestefanyadvocaciame.com.br", Telefone = "(11) 2983-9664" },
                    new Cliente { Codigo = 5, Nome = "Kevin e Agatha Marketing ME", Email = "estoque@kevineagathamarketingme.com.br", Telefone = "(11) 2825-2291"}
                );
            });
    }
    }}

