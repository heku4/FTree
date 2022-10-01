using FTree.Configuration;
using MongoDB.Driver;

namespace FTree.Services.MongoService
{

    public class MongoService
    {
        private readonly string _connectionString;
        private readonly MongoClient _client;
        
        public MongoService(AppConfiguration config)
        {
            _connectionString = config.MongoConfig.ConnectionString;
            _client = new MongoClient(_connectionString);
        }

        public bool CheckConnection()
        {
            var conStatus = _client.GetDatabase("test");
            return conStatus != null;
        }
    }
}
