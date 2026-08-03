using KfSoft.EFCore.Context;
using KfSoft.Domain.Entities;

try
{
    using (AppDbContext context = new AppDbContext())
    {

        context.Database.EnsureDeleted();
        Console.WriteLine("Criando Banco de dados");
        context.Database.EnsureCreated();

        Console.WriteLine("Criando Departamentos");
        CriarDepartamento(context);
        Console.WriteLine("Departamentos Criados");
        Console.WriteLine("Pressione qualquer tecla para continuar...");

    }
    Console.ReadKey();
    Console.Clear();

    using (AppDbContext context = new AppDbContext())
    {
        //var departamentos = context.Departamentos.ToList();
        //Console.WriteLine("======= DEPARTAMENTOS ========");
        //foreach (var departamento in departamentos)
        //{
        //    Console.WriteLine($"Id: {departamento.Codigo} - Nome: {departamento.Nome} - Descrição: {departamento.Descricao} - Data de Criação: {departamento.DataCriacao}");
        //}


        var departamento = context.Departamentos.FirstOrDefault(d => d.Codigo == 3);
        Console.WriteLine(departamento != null
            ? $"Id: {departamento.Codigo} - Nome: {departamento.Nome} - Descrição: {departamento.Descricao} - Data de Criação: {departamento.DataCriacao}"
            : "Departamento não encontrado");
        Console.ReadKey();
        Console.Clear();
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

    void CriarDepartamento(AppDbContext context)
{

    var departamentos = new List<Departamento>()
    {
        new Departamento{Nome = "Departamento de TI", Descricao = "Departamento de Tecnologia da Informação"},
        new Departamento{Nome = "Marketing", Descricao = "Departamento de Marketing"},
        new Departamento{Nome = "RH", Descricao = "Departamento de Recursos Humanos"},
        new Departamento{Nome = "Financeiro", Descricao = "Departamento de Gestao do Financeiro"}
    };
    context.AddRange(departamentos);
    context.SaveChanges();

}



try
{
    using(AppDbContext context = new AppDbContext())
    {
        Console.WriteLine("Criando Banco de Dados...");
        context.Database.EnsureCreated();
        Console.WriteLine("Banco de Dados Criado!");
        CriarProjeto(context);
        Console.WriteLine("Projeto Criado com sucesso!");
        Console.ReadKey();
        Console.Clear();

    }

    using (AppDbContext context = new AppDbContext())
    { 
    var projetos = context.Projetos.ToList();
        Console.WriteLine("======= PROJETOS ========");
        foreach (var projeto in projetos)
        {
            Console.WriteLine($"Id: {projeto.Codigo} - Descrição: {projeto.Descricao} - Responsável: {projeto.Responsavel} - Data de Início: {projeto.DataInicio} - Status: {(projeto.Status ? "Ativo" : "Inativo")}");
        }
        Console.ReadKey();
        Console.Clear();
    }
} catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

void CriarProjeto(AppDbContext context)
{
    var projetos = new List<Projeto>()
    {
        new Projeto{Descricao = "Desenvolvimento de Sistema de Gestão", Responsavel = "Kauã Fragozo", Status = false},
        new Projeto{Descricao="Melhorias no Banco de Dados da Empresa'", Responsavel = "Kauã Fragozo", Status = true},
    };


    context.AddRange(projetos);
    context.SaveChanges();
}