using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace MeuControleFinanceiro.Repository
{
    public class DespesaRepository : Servicos.IDespesaRepository
    {

        DB.IDBContext repository;

        public DespesaRepository(DB.IDBContext repository)
        {
            this.repository = repository;
        }


        public void AddDespesa(DespesaModel despesa)
        {
            var response = repository.GetCollection<DespesaModel>("Despesa");

            despesa._id = repository.GetNextSequence("Despesa");

            response.InsertOne(despesa);

        }



        public IEnumerable<DespesaModel> Get()
        {
            return repository.GetCollections<DespesaModel>("Despesa");
        }
    }
}