using MeuControleFinanceiro.DB;
using MeuControleFinanceiro.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private IDBContext db;

        public LancamentoRepository(IDBContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {

            var response = db.GetCollections<LancamentoModel>("Lancamento");
            
            var deleteFilter = Builders<LancamentoModel>.Filter.Eq("_id", id);
         
            db.GetCollection<LancamentoModel>("Despesa").DeleteOne(deleteFilter);

        }

        public IEnumerable<LancamentoModel> GetAll()
        {
            return db.GetCollections<LancamentoModel>("Lancamento");
        }

        public IEnumerable<LancamentoModel> GetCartaoCredito()
        {
            return db.GetCollections<LancamentoModel>("Lancamento").Where(a => a.TipoLancamento == "CARTAOCREDITO");
        }

        public IEnumerable<LancamentoModel> GetDesepesa()
        {
            return db.GetCollections<LancamentoModel>("Lancamento").Where(a => a.TipoLancamento == "DESPESA");
        }

        public int GetNextValue()
        {
            return db.GetCollections<LancamentoModel>("Lancamento").Max(x => Convert.ToInt32(x._id)) + 1;
        }

        public IEnumerable<LancamentoModel> GetReceita()
        {
            return db.GetCollections<LancamentoModel>("Lancamento").Where(a => a.TipoLancamento == "RECEITA");
        }

        public void Insert(LancamentoModel lancamento)
        {
            lancamento._id = GetNextValue();

            db.GetCollection<LancamentoModel>("Lancamento").InsertOne(lancamento);

        }
    }
}