using FTree.Configuration;
using FTree.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FTree.Services.TreeNodeRepository.MongoService
{

    public class MongoService: ITreeNodeRepository
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

        public async Task DeleteFromRepository(int id)
        {
            var db = _client.GetDatabase(_databaseName);
            var collection = db.GetCollection<TreeNode>(_collectionName);
            var result = await collection.DeleteOneAsync<TreeNode>(
                t => t.FamilyId == id);

            if(result.DeletedCount < 1)
            {
                throw new Exception($"Can't delete instance with ID: {id}"); 
            }
        }

        public async Task<TreeNode> GetFromRepository(int id)
        {
            var db = _client.GetDatabase(_databaseName);
            var collection = db.GetCollection<TreeNode>(_collectionName);
            var cursor = await collection.FindAsync<TreeNode>(t => t.FamilyId == id);
            var treeNode = await cursor.FirstOrDefaultAsync();

            if(treeNode is null)
            {
                throw new KeyNotFoundException(); 
            }

            return treeNode;
        }

        public async Task UpdateInRepository(TreeNode treeNode)
        {
            var db = _client.GetDatabase(_databaseName);
            var collection = db.GetCollection<TreeNode>(_collectionName);
            var cursor = collection.FindOneAndReplaceAsync<TreeNode>(
                t => t.FamilyId == treeNode.FamilyId, 
                treeNode);
            var updatedNode = await cursor;

            if(updatedNode is null)
            {
                throw new Exception($"Can't update instance with ID: {treeNode.FamilyId}"); 
            }
        }

        public async Task WriteToRepository(TreeNode treeNode)
        {
            var db = _client.GetDatabase(_databaseName);
            var collection = db.GetCollection<TreeNode>(_collectionName);
            await collection.InsertOneAsync(treeNode);
        }
    }
}
