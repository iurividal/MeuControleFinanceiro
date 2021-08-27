using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro
{
    public static class HelpersExtensions
    {

        public static string FormatCurrency(double? valor)
        {
            if (valor == null)
                return "0,00";

            return Convert.ToDecimal(valor).ToString("n2");
        }

        public static string FormatCurrency(double valor)
        {

            return Convert.ToDecimal(valor).ToString("n2");
        }





    }
}