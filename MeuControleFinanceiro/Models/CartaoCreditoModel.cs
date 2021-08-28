using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Models
{
    public class CartaoCreditoModel
    {
        public string Descricao { get; set; }

        public decimal ValorLimite { get; set; }

        public int idContaPadrao { get; set; }

        public DateTime Vencimento { get; set; }

    }

    public class CartaoCreditoDetalhe : LancamentoModel
    {

       

    }
}