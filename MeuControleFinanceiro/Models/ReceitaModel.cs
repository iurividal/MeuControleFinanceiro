using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Models
{

    public class LancamentoModel
    {
        public object _id { get; set; }

        public string Descricao { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DataLacamento { get; set; }

        public string DataLacamentoStr { get => DataLacamento.ToString("dd/MM/yyyy"); }

        public double Valor { get; set; }

        public int MesLancamento => DataLacamento.Month;

        public string _idConta { get; set; }

        public string _idCategoria { get; set; }

    }

    public class ReceitaModel : LancamentoModel
    {
    }

    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd-MMM-yyyy";
        }
    }
}