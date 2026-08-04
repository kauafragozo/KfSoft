using KfSoft.EFCore.Context;
using KfSoft.Domain.Entities;


    using (AppDbContext context = new AppDbContext())
    {

        context.Database.EnsureDeleted();
        Console.WriteLine("Criando Banco de dados");
        context.Database.EnsureCreated();

        Console.WriteLine("Departamentos Criados");
        Console.WriteLine("Funcionarios Criados");
        Console.WriteLine("Pressione qualquer tecla para continuar...");

    }
    Console.ReadKey();
    Console.Clear();
