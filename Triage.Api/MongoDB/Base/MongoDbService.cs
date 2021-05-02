using Microsoft.Extensions.Options;
using Models.AppSettings;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDB.Base
{
    public partial class MongoDBService
    {
        private readonly MongoUrl _mongoUrl;
        private MongoClient _mongoClient;
        public MongoDBService(IOptions<MongoDbSetting> apiOptions)
        {
            _mongoUrl = MongoUrl.Create(apiOptions.Value.ConnectionString);
        }
        private MongoClient GetClient()
        {
            if (_mongoClient == null)
                _mongoClient = new MongoClient(_mongoUrl);
            return _mongoClient;
        }
        private IMongoDatabase GetDatabase()
        {
            try
            {
                return GetClient().GetDatabase(_mongoUrl.DatabaseName);
            }
            catch (Exception ex)
            {
                _mongoClient = null;
                throw ex;
            }

        }
        public string GetUniqueMongoDatabaseIDForRecord()
        {
            string result = ObjectId.GenerateNewId().ToString();
            return result;
        }
        public IMongoCollection<TDocument> GetCollection<TDocument>(string collection)
        {
            return GetDatabase().GetCollection<TDocument>(collection);
        }
        public IMongoCollection<BsonDocument> GetCollection(string collection)
        {
            return GetDatabase().GetCollection<BsonDocument>(collection);
        }
    }
}
