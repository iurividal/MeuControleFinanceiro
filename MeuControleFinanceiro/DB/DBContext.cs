using MeuControleFinanceiro.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.DB
{
    public class DBContext
    {

        public IMongoDatabase GetDataBaseMongo()
        {

         

            var settings = MongoClientSettings.FromConnectionString("mongodb://iurividal10:6DeF9hYwj9zNyZC@cluster0-shard-00-00.8xntn.mongodb.net:27017,cluster0-shard-00-01.8xntn.mongodb.net:27017,cluster0-shard-00-02.8xntn.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=atlas-qzlnoh-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("ControleFinanceiro");
            return database;

        }


      






    }
}