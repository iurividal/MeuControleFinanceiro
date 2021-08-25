using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Repository
{
    public class ContaRepositoty
    {

        public static IEnumerable<ContaModel> GetContas()
        {
            IEnumerable<ContaModel> ct = new List<ContaModel>
            {
                new ContaModel{IdConta=1, Nome = "Conta Corrente", ValorInicial = 1000, SaldoAtual = GetSaldoAtualConta(1)},
                new ContaModel{IdConta=2, Nome = "Conta Poupança", ValorInicial = 1000, SaldoAtual = GetSaldoAtualConta(2)},

            };

            return ct;

        }


        public static double GetSaldoAtualConta(int id)
        {
            return new Random().NextDouble();
        }

    }
}