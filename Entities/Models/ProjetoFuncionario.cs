namespace KfSoft.Entities
{
    public class ProjetoFuncionario
    {
        public int ProjetoCodigo{ get; set;}
        public Projeto? Projeto { get; set;}
        public int FuncionarioCodigo{get;set;}
        public Funcionario? Funcionario { get; set;}
        public int HorasTrabalhadas { get; set;}
    }
}