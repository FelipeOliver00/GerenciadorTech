using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorTech.Models
{
    public class Funcionario
    {
        [HiddenInput]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        
        [Display(Name ="Data de Início"),DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }
        public Departamento Departamento { get; set; }
        
        [Display(Name ="Funcionário HomeFull")]
        public bool HomeFull { get; set; }

        [Display(Name ="Centro de Custo")]
        public int CentroCusto { get; set; }
    }
}
