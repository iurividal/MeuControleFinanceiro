using MeuControleFinanceiro.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.DB
{
    public class DBContext : IDBContext
    {

        public IMongoDatabase GetDataBaseMongo()
        {


            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://iurividal10:6DeF9hYwj9zNyZC@cluster0.8xntn.mongodb.net/cluster0?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("ControleFinanceiro");

            return database;

        }

        public IMongoCollection<BsonDocument> GetCollection(string collection)
        {
            return GetDataBaseMongo().GetCollection<BsonDocument>(collection);
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string collection)
        {
            return GetDataBaseMongo().GetCollection<TDocument>(collection);
        }

    }
}