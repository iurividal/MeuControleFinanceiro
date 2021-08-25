using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Repository
{
    public class ReceitaRepository
    {
        public static IEnumerable<ReceitaModel> GetReceitas
        {
            get
            {


           IEnumerable<ReceitaModel> receitas = new List<ReceitaModel>
            {
                new ReceitaModel{ Descricao = "Salário", Valor = 2000.00, DataReceita= new DateTime(2021,08,31), Conta = new ContaModel{Nome = "C6 Bank"} },
                new ReceitaModel{ Descricao = "Adiantamento", Valor = 1800.00, DataReceita= new DateTime(2021,08,20),Conta = new ContaModel{Nome = "C6 Bank"} }
            };


                return receitas;
            }
        }
    }
}