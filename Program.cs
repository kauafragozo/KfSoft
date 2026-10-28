using System.Runtime.InteropServices.Marshalling;
using KfSoft.Context;
using KfSoft.Entities;

namespace CatalogoFilmes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (AppDbContext context = new AppDbContext())
            {

                context.Database.EnsureDeleted();
                Console.WriteLine("Criando Banco de dados");
                context.Database.EnsureCreated();

                Console.WriteLine("Departamentos Criados");
                Console.WriteLine("Projetos Criados");
                Console.WriteLine("Funcionarios Criados");
                Console.WriteLine("Pressione qualquer tecla para continuar...");

                Console.ReadKey();
                Console.Clear();

               
                    var funcionario = new Funcionario
                    {
                        Nome = "Synister Gates",
                        Cargo = "Desenvolvedor Pleno",
                        Salario = 50000m,
                        DepartamentoCodigo = 5,
                        FuncionarioDetalhe = new FuncionarioDetalhe {
                            EnderecoResidencial = "Rua Jacinto Dantas",
                            DataNascimento = new DateTime(1981, 6, 7),
                            Celular = "(84) 2738-4429",
                            Genero = Genero.Masculino,
                            EstadoCivil = EstadoCivil.Casado,
                            CPF = "142.802.390-96",
                            Nacionalidade = "Estados-Unidense",
                            Escolaridade = Escolaridade.Medio,
                            FuncionarioCodigo = 33

                        }

                    };
                    context.Funcionarios.Add(funcionario);
                    context.SaveChanges();

                    var projeto = new Projeto
                    {
                        Nome = "Sistema Gerenciador de Maratonas",
                        Descricao = "Sistema gerenciador de maratonas, participantes e premiaçoes",
                        Orcamento = 100000m,
                        Status = StatusProjeto.Concluido,
                        ClienteCodigo = 1

                    };
                    context.Projetos.Add(projeto);
                    context.SaveChanges();

                    var projetoFuncionario = new ProjetoFuncionario
                    {
                        ProjetoCodigo = projeto.Codigo,
                        FuncionarioCodigo = funcionario.Codigo,
                        HorasTrabalhadas = 136
                    };
                    context.ProjetoFuncionario.Add(projetoFuncionario);
                    context.SaveChanges();
                

            }

        }
    }
}




