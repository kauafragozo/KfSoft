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
    AdicionarFuncionarioRelacional(context);


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


void AdicionarFuncionarioRelacional(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "Departamento de Marketing",
        Descricao = "Departamento de Marketing e Vendas"
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









