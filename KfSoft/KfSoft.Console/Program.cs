using KfSoft.EFCore.Context;
using KfSoft.Domain.Entities;


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

    AdicionarFuncionarioAdd(context);
    AdicionarFuncionarioAddRange(context);
    AdicionarFuncionarioAddRelacional(context);
    AdicionarFuncionarioAddRangeRelacional(context);

    AdicionarFuncionarioDetalheAdd(context);
    AdicionarFuncionarioDetalheAddRange(context);
    AdicionarFuncionarioDetalheAddRelacional(context);
    AdicionarFuncionarioDetalheAddRangeRelacional(context);

}

void AdicionarFuncionarioAdd(AppDbContext context)
{
    var funcionario = new Funcionario
    {
        Nome = "Kauã Fragozo",
        Cargo = "Desenvolvedor Senior",
        Salario = 50000.00m,
        DepartamentoCodigo = 1
    };
    context.Funcionarios.Add(funcionario);
    context.SaveChanges();
}

void AdicionarFuncionarioAddRange(AppDbContext context)
{
    var funcionarios = new List<Funcionario>
    {
        new Funcionario
        {
            Nome = "João Silva",
            Cargo = "Analista de Sistemas",
            Salario = 3000.00m,
            DepartamentoCodigo = 1
        },
        new Funcionario
        {
            Nome = "Maria Souza",
            Cargo = "Analista de Recursos Humanos",
            Salario = 3500.00m,
            DepartamentoCodigo = 2
        }
    };
    context.Funcionarios.AddRange(funcionarios);
    context.SaveChanges();
}


void AdicionarFuncionarioAddRelacional(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "Departamento de Marketing",
        Descricao = "Departamento de Marketing "
    };
    departamento.Funcionarios.Add(new Funcionario
    {
        Nome = "Carlos Oliveira",
        Cargo = "Analista de Marketing",
        Salario = 4000.00m,

    });

    context.Departamentos.Add(departamento);
    context.SaveChanges();

}

void AdicionarFuncionarioAddRangeRelacional(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "Departamento de Vendas",
        Descricao = "Departamento de Vendas"
    };
    departamento.Funcionarios = new List<Funcionario>
    {
        new Funcionario
        {
            Nome = "Ana Paula",
            Cargo = "Vendedora",
            Salario = 2500.00m,
        },
        new Funcionario
        {
            Nome = "Pedro Henrique",
            Cargo = "Vendedor",
            Salario = 2800.00m,
        }
    };
    context.Departamentos.AddRange(departamento);
    context.SaveChanges();


}

void AdicionarFuncionarioDetalheAdd(AppDbContext context)
{
    var funcionariodetalhe = new FuncionarioDetalhe
    {
        EnderecoResidencial = "Rua das Flores, 123",
        DataNascimento = new DateTime(1990, 5, 15),
        Celular = "(11) 98765-4321",
        Genero = "Masculino",
        Foto = null,
        EstadoCivil = "Solteiro",
        CPF = "123.456.789-00",
        Nacionalidade = "Brasileiro",
        Escolaridade = "Superior Completo",
        FuncionarioCodigo = 1
    };
    context.Add(funcionariodetalhe);
    context.SaveChanges();
}

void AdicionarFuncionarioDetalheAddRange(AppDbContext context)
{
    var funcionariosDetalhes = new List<FuncionarioDetalhe>
    {
        new FuncionarioDetalhe
        {
            EnderecoResidencial = "Rua das Palmeiras, 456",
            DataNascimento = new DateTime(1985, 8, 20),
            Celular = "(21) 98765-4321",
            Genero = "Feminino",
            Foto = null,
            EstadoCivil = "Casada",
            CPF = "987.654.321-00",
            Nacionalidade = "Brasileira",
            Escolaridade = "Mestrado",
            FuncionarioCodigo = 2
        },
        new FuncionarioDetalhe
        {
            EnderecoResidencial = "Avenida Brasil, 789",
            DataNascimento = new DateTime(1992, 3, 10),
            Celular = "(31) 98765-4321",
            Genero = "Masculino",
            Foto = null,
            EstadoCivil = "Solteiro",
            CPF = "456.789.123-00",
            Nacionalidade = "Brasileiro",
            Escolaridade = "Doutorado",
            FuncionarioCodigo = 3
        }
    };
    context.AddRange(funcionariosDetalhes);
    context.SaveChanges();
}

void AdicionarFuncionarioDetalheAddRelacional(AppDbContext context)
{
    var funcionario = new Funcionario
    {
        Nome = "Lucas Pereira",
        Cargo = "Desenvolvedor Junior",
        Salario = 2000.00m,
        DepartamentoCodigo = 1,
        FuncionarioDetalhe = new FuncionarioDetalhe
        {
            EnderecoResidencial = "Rua das Acácias, 321",
            DataNascimento = new DateTime(1995, 12, 5),
            Celular = "(41) 98765-4321",
            Genero = "Masculino",
            Foto = null,
            EstadoCivil = "Solteiro",
            CPF = "321.654.987-00",
            Nacionalidade = "Brasileiro",
            Escolaridade = "Superior Incompleto"
        }
    };
    context.Funcionarios.Add(funcionario);
    context.SaveChanges();

}

void AdicionarFuncionarioDetalheAddRangeRelacional(AppDbContext context)
{
    var funcionarios = new List<Funcionario>
    {
        new Funcionario
        {
            Nome = "Fernanda Lima",
            Cargo = "Analista de Marketing",
            Salario = 4000.00m,
            DepartamentoCodigo = 2,
            FuncionarioDetalhe = new FuncionarioDetalhe
            {
                EnderecoResidencial = "Rua das Margaridas, 654",
                DataNascimento = new DateTime(1988, 7, 25),
                Celular = "(51) 98765-4321",
                Genero = "Feminino",
                Foto = null,
                EstadoCivil = "Casada",
                CPF = "654.321.987-00",
                Nacionalidade = "Brasileira",
                Escolaridade = "Superior Completo"
            }
        },
        new Funcionario
        {
            Nome = "Rafael Santos",
            Cargo = "Analista de Sistemas",
            Salario = 3500.00m,
            DepartamentoCodigo = 1,
            FuncionarioDetalhe = new FuncionarioDetalhe
            {
                EnderecoResidencial = "Avenida das Nações, 987",
                DataNascimento = new DateTime(1991, 11, 15),
                Celular = "(61) 98765-4321",
                Genero = "Masculino",
                Foto = null,
                EstadoCivil = "Solteiro",
                CPF = "789.123.456-00",
                Nacionalidade = "Brasileiro",
                Escolaridade = "Mestrado"
            }
        }
    };
    context.Funcionarios.AddRange(funcionarios);
    context.SaveChanges();
}
















