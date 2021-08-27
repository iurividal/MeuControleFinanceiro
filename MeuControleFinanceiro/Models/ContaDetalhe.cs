using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Models
{
    public class ContaDetalhe : ContaModel
    {

        public double? SaldoAtual;

        public double? TotalDespesa { get; set; }

        public IEnumerable<ReceitaModel> Receitas { get; set; }

        public double? TotalReceita { get; set; }

    }
}