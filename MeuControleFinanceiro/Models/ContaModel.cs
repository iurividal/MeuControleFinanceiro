using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Models
{
    

    public class ContaModel
    {
        public object _id { get; set; }

        [DisplayName("Nome da Conta")]
        public string Nome { get; set; }

        public double ValorInicial { get; set; }      
       
        [DisplayName("Conta Padrão")]
        public string Padrao { get; set; }

    }
}