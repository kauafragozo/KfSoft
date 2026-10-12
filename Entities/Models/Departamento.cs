using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KfSoft.Domain.Entities
{
    public class Departamento
    {
       
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    }
}
 