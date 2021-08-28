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
            var contas = db.GetCollection<ContaModel>("Conta");

            var lancamento = db.GetCollection<LancamentoModel>("Lancamento");

            //var despesas = db.GetCollection<DespesaModel>("Despesa");
            
            //var result = contas.Aggregate().Lookup("Receita", "Valor", "_idConta", @as: "receita_docs")
            //    .Unwind("receita_docs")
            //    .As<ContaDetalhe>()
            //    .ToEnumerable();

            //var docs = contas.Aggregate()
            //      .Lookup("Receita", "_idConta", "_id", "Receitas")
            //      .As<BsonDocument>()
            //      .ToList();


            var result = (from c in contas.AsQueryable()
                          select new ContaDetalhe
                          {
                              Nome = c.Nome,
                              _id = c._id,
                              ValorInicial = c.ValorInicial


                          }).ToList();



            foreach (var item in result)
            {
                int idcota = Convert.ToInt32(item._id);

                item.TotalReceita = lancamento.AsQueryable().Where(a => a._idConta == idcota && a.TipoLancamento == "RECEITA").Sum(a => a.Valor);

                item.TotalDespesa = lancamento.AsQueryable().Where(a => a._idConta == idcota && a.TipoLancamento == "DESPESA").Sum(a => a.Valor);

                item.SaldoAtual = item.ValorInicial + (item.TotalReceita - item.TotalDespesa);  
                

            }





            return result;


        }




        public double ConsultarSaldoConta(string id)
        {
            var receitas = db.GetDataBaseMongo().GetCollection<ReceitaModel>("Receita")
                    .AsQueryable<ReceitaModel>()
                    .Where(a => a._idConta == Convert.ToInt32(id)).Sum(a => a.Valor);

            var despensas = db.GetDataBaseMongo().GetCollection<DespesaModel>("Despesa")
                        .AsQueryable<DespesaModel>()
                        .Where(a => a._idConta == Convert.ToInt32(id)).Sum(a => a.Valor);


            var saldoInicial = GetContas().Where(a => Convert.ToInt32(a._id) == Convert.ToInt32(id)).Sum(a => a.ValorInicial);

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