using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MeuControleFinanceiro.DB;
using MeuControleFinanceiro.Repository.Servicos;

namespace MeuControleFinanceiro.Repository
{
    public class ReceitaRepository : IReceitaRepository
    {
        //DB.DBContext db = new DB.DBContext();

        private readonly IDBContext db;

        public ReceitaRepository(IDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<ReceitaModel> GetReceitas()
        {
            {

                var receita = db.GetCollection<ReceitaModel>("Receita").AsQueryable();
                return receita;
            }
        }

        public void AddReceita(ReceitaModel receitaModel)
        {
            var receita = db.GetCollection<ReceitaModel>("Receita");

            receitaModel._id = receita.AsQueryable<ReceitaModel>().Count() + 1;

            receita.InsertOne(receitaModel);

        }
    }
}