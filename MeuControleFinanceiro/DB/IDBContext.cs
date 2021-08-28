using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuControleFinanceiro.DB
{
    public interface IDBContext
    {

        IMongoDatabase GetDataBaseMongo();

        IMongoCollection<BsonDocument> GetCollection(string collection);

        IMongoCollection<TDocument> GetCollection<TDocument>(string collection);

        IEnumerable<T> GetCollections<T>(string collection);

        int GetNextSequence(string collection);
    }
}
