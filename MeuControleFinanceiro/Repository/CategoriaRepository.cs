using MeuControleFinanceiro.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Driver.Linq;

namespace MeuControleFinanceiro.Repository
{
    public class CategoriaRepository
    {
        private static DB.DBContext db = new DB.DBContext();



        public static IEnumerable<CategoriaModel> GetCategoria
        {
            get
            {

                var catagoriaList = db.GetDataBaseMongo()
                    .GetCollection<CategoriaModel>("Categoria");


                var query = from e in catagoriaList.AsQueryable<CategoriaModel>()
                            select e;

                //IEnumerable<CategoriaModel> cat = new List<CategoriaModel>
                //    {
                //        new CategoriaModel(1,"Fixa"),
                //        new CategoriaModel(2,"Outros"),
                //        new CategoriaModel(3,"Automovel"),
                //        new CategoriaModel(4,"Alimentação"),
                //    };



                return query.ToList();
            }
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

        public static IEnumerable<SubCategoria> GetSubCategoria
        {
            get
            {
                IEnumerable<SubCategoria> cat = new List<SubCategoria>
                    {
                        new SubCategoria(1,"Combustivel"),
                        new SubCategoria(2,"Outros"),
                        new SubCategoria(3,"Comissão"),


                    };


                return cat;
            }
        }

    }
}