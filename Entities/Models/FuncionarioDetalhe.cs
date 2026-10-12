using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KfSoft.Domain.Entities
{
    public class FuncionarioDetalhe
    {

        public int Codigo { get; set; }
        public string EnderecoResidencial { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public string Celular { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string? Foto { get; set; }
        public string EstadoCivil { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;
        public string Escolaridade { get; set; } = string.Empty;

        public int FuncionarioCodigo { get; set; }
        public Funcionario? Funcionario { get; set; }
    }

}