﻿using FTree.Configuration;
using MongoDB.Driver;

namespace FTree.Services.MongoService
{

    public class MongoService
    {
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly MongoClient _client;
        
        public MongoService(AppConfiguration config)
        {
            _connectionString = config.MongoConfig.ConnectionString;
            _client = new MongoClient(_connectionString);
            _databaseName = config.MongoConfig.DatabaseName;
            _collectionName = config.MongoConfig.DatabaseName;
        }

        public bool CheckConnection()
        {
            var conStatus = _client.GetDatabase("test");
            return conStatus != null;
        }

        public async Task InsertDocument<TreeNdoe>(TreeNdoe document)
        {
            var db = _client.GetDatabase(_databaseName);
            var collection = db.GetCollection<TreeNdoe>(_collectionName);
            await collection.InsertOneAsync(document);
        }
    }
}
