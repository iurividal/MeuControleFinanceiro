using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Models
{
    public class ReceitaModel
    {
        public string Descricao { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DataReceita { get; set; }
        public double Valor { get; set; }
        public int MesReceita => DataReceita.Month;

        public string DataReceitaStr => DataReceita.ToString("dd/ddd");

        public ContaModel Conta { get; set; }

        public CategoriaModel Categoria { get; set; }


    }

    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd-MMM-yyyy";
        }
    }
}