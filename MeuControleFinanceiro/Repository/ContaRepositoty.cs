using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;
using MeuControleFinanceiro.DB;
using MeuControleFinanceiro.Repository.Servicos;

namespace MeuControleFinanceiro.Repository
{
    public class ContaRepository : IContaRepository
    {
        IDBContext db;
       
        public ContaRepository(IDBContext db, IReceitaRepository repositoryReceita)
        {
            this.db = db;
        }


        public IEnumerable<ContaModel> GetContas()
        {
            var response = db.GetDataBaseMongo().GetCollection<ContaModel>("Conta");


            var lista = (from c in response.AsQueryable<ContaModel>()
                         select new ContaModel
                         {
                             Nome = c.Nome,
                             Padrao = c.Padrao,
                             ValorInicial = c.ValorInicial,
                             _id = c._id


                         }).ToList();


            return lista;


        }

        public IEnumerable<ContaDetalhe> GetContaDetalhe()
        {
            var contas = db.GetDataBaseMongo().GetCollection<ContaModel>("Conta");

            var receitas = db.GetDataBaseMongo().GetCollection<ReceitaModel>("Receita");


            //var result = contas.Aggregate().Lookup("Receita", "Valor", "_idConta", @as: "receita_docs")
            //    .Unwind("receita_docs")
            //    .As<ContaDetalhe>()
            //    .ToEnumerable();

            var docs = contas.Aggregate()
                  .Lookup("Receita", "_idConta", "_id", "Receitas")
                  .As<BsonDocument>()
                  .ToList();


            var result = (from c in contas.AsQueryable()
                          join r in receitas.AsQueryable() on c._id equals r._idConta
                          into joinedInventory
                          select new ContaDetalhe
                          {
                              Nome = c.Nome,
                              Receitas = joinedInventory

                          }).ToList();


            return result;


        }




        public double ConsultarSaldoConta(string id)
        {
            var receitas = db.GetDataBaseMongo().GetCollection<ReceitaModel>("Receita")
                    .AsQueryable<ReceitaModel>()
                    .Where(a => a._idConta == id).Sum(a => a.Valor);

            var despensas = db.GetDataBaseMongo().GetCollection<DespesaModel>("Despesa")
                        .AsQueryable<DespesaModel>()
                        .Where(a => a._idConta == id).Sum(a => a.Valor);


            var saldoInicial = GetContas().Where(a => a._id == id).Sum(a => a.ValorInicial);

            var saldoAtual = (receitas - despensas) + saldoInicial;

            return saldoAtual;
        }

        public void AddConta(ContaModel conta)
        {

            var response = db.GetDataBaseMongo().GetCollection<ContaModel>("Conta");

            conta._id = response.AsQueryable<ContaModel>().Count() + 1;

            response.InsertOne(conta);


        }



    }
}