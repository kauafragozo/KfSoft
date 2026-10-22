using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace KfSoft.Entities
{
    public class Cliente
    {
        public int Codigo { get; set;}
        public string Nome { get; set;} = string.Empty;
        public string Email { get; set;} = string.Empty;
        public string Telefone { get; set;} = string.Empty;

        public ICollection <Projeto> Projetos { get ;set;} = 
        new List<Projeto>();
    }
}