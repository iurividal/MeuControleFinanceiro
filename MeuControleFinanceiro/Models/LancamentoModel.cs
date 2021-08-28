using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeuControleFinanceiro.Models
{
    public class LancamentoModel
    {

        [BsonId]
        public object _id { get; set; }

        public string Descricao { get; set; }

        //[JsonConverter(typeof(CustomDateTimeConverter))]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DataLancamento { get; set; } = DateTime.Now;

        public string DataLancamentoStr => DataLancamento.ToString("dd/MM/yyyy");

        public double Valor { get; set; }

        public string Recorrencia { get; set; }

        public int MesLancamento => DataLancamento.Month;

        public int _idConta { get; set; }

        public string _idCategoria { get; set; }

        public string TipoLancamento { get; set; }
    }


    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd-MMM-yyyy";
        }
    }
}