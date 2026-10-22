using Microsoft.Identity.Client.Advanced;

namespace KfSoft.Entities
{
    public class Projeto
    {
        public int Codigo { get; set;}
        public string Nome { get; set;} = string.Empty;
        public string Descricao { get; set;} = string.Empty;
        public decimal Orcamento { get; set;}
        public DateTime DataInicio { get; set;}
        public DateTime? DataAtualizacao { get; set;}
        public DateTime? DataConclusao { get; set;}
        public StatusProjeto? Status { get; set;}
        public int ClienteCodigo { get; set;} 
        public Cliente? Cliente { get; set;}
    }
}