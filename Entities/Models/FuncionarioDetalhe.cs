using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KfSoft.Entities
{
    public class FuncionarioDetalhe
    {

        public int Codigo { get; set; }
        public string EnderecoResidencial { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public string Celular { get; set; } = string.Empty;
        public Genero? Genero { get; set; }
        public string? Foto { get; set; }
        public EstadoCivil? EstadoCivil { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;
        public Escolaridade? Escolaridade { get; set; }

        public int FuncionarioCodigo { get; set; }
        public Funcionario? Funcionario { get; set; }
    }

}