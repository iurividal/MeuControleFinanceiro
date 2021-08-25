using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace MeuControleFinanceiro.Repository
{
    public class ContaRepositoty
    {
        DB.DBContext db = new DB.DBContext();

        public IEnumerable<ContaModel> GetContas()
        {
            var response = db.GetDataBaseMongo().GetCollection<ContaModel>("Conta");

            return response.AsQueryable<ContaModel>();


        }

        //public IEnumerable<ContaDetalhe> GetContasDetalhe()
        //{
        //    var conta = db.GetDataBaseMongo().GetCollection<ContaModel>("Conta").AsQueryable<ContaModel>();
        //    var despensa = db.GetDataBaseMongo().GetCollection<DespesaModel>("Despesa").AsQueryable<DespesaModel>();
        //    var Receita = db.GetDataBaseMongo().GetCollection<ReceitaModel>("Receita").AsQueryable<ReceitaModel>();

        //    return 
        //}


        public static double GetSaldoAtualConta(int id)
        {
            return new Random().NextDouble();
        }

        public void AddConta(ContaModel conta)
        {

            var response = db.GetDataBaseMongo().GetCollection<ContaModel>("Conta");

            conta._id = response.AsQueryable<ContaModel>().Count() + 1;

            response.InsertOne(conta);


        }

    }
}