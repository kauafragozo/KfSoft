using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KfSoft.Domain.Entities
{
    public class Projeto
    {

        public int Codigo { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Responsavel {get ; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Status { get; set; }

       public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    }
}
