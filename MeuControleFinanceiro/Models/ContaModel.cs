using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Models
{
    public class ContaModel
    {

        public int IdConta { get; set; }

        public string Nome { get; set; }

        public double ValorInicial { get; set; }

        public double SaldoAtual { get; set; }

        public ReceitaModel Receita { get; set; } = new ReceitaModel();

        public DespesaModel Despesa { get; set; } = new DespesaModel();

        public bool IsPadrao { get; set; }

        public double ChequeEspecial { get; set; }
    }
}