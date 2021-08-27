using MeuControleFinanceiro.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using MeuControleFinanceiro.DB;

namespace MeuControleFinanceiro.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        IDBContext db;

        public CategoriaRepository(IDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<CategoriaModel> GetCategoria()
        {

            var catagoriaList = db.GetCollection<CategoriaModel>("Categoria").AsQueryable();                                 

            return catagoriaList;

        }

        public void AddCategoria(CategoriaModel categoria)
        {
            try
            {
                var lista = db.GetDataBaseMongo().GetCollection<CategoriaModel>("Categoria");
                lista.InsertOne(categoria);
            }
            catch (System.Exception)
            {
                throw;
            }



        }


    }
}