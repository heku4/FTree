using FTree.Configuration;
using FTree.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FTree.Services.MongoService
{

    public class MongoService
    {
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly MongoClient _client;
        private readonly BsonClassMap _classMap;
        
        public MongoService(AppConfiguration config)
        {
            _connectionString = config.MongoConfig.ConnectionString;
            _client = new MongoClient(_connectionString);
            _databaseName = config.MongoConfig.DatabaseName;
            _collectionName = config.MongoConfig.DatabaseName;
            _classMap = BsonClassMap.RegisterClassMap<TreeNode>(tr =>
            {
                tr.MapMember(c => c.FamilyMember);
                tr.MapMember(c => c.Children);
                tr.MapMember(c => c.Parents);
            });
        }

        public bool CheckConnection()
        {
            var conStatus = _client.GetDatabase("test");
            return conStatus != null;
        }

        public async Task InsertDocument<T>(T document)
        {
            var db = _client.GetDatabase(_databaseName);
            var collection = db.GetCollection<T>(_collectionName);
            await collection.InsertOneAsync(document);
        }
    }
}
