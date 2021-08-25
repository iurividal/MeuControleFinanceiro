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
                new ReceitaModel{ Descricao = "Salário", Valor = 2000.00, DataReceita= new DateTime(2021,08,31), IdConta= 1},
                new ReceitaModel{ Descricao = "Adiantamento", Valor = 1800.00, DataReceita= new DateTime(2021,08,20), IdConta = 1}
            };


                return receitas;
            }
        }
    }
}