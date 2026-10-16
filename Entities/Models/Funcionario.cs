using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KfSoft.Entities
{
    public  class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public DateOnly DataAdimissao { get; set; }
        
        public int DepartamentoCodigo { get; set; }
        public Departamento? Departamento { get; set; }
        public FuncionarioDetalhe? FuncionarioDetalhe { get; set; }

    }
}
