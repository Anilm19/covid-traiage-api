using Models.Entity.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace MongoDB.Base
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly MongoDBService mongoDBService;
        public readonly string COLLECTION_NAME;
        public GenericRepository(MongoDBService _mongoDBService)
        {
            mongoDBService = _mongoDBService;
            MongoCollectionNameAttribute collectionNameAttribute =
            (MongoCollectionNameAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(MongoCollectionNameAttribute));
            if (collectionNameAttribute == null)
                COLLECTION_NAME = typeof(T).Name;
            else
                COLLECTION_NAME = collectionNameAttribute.CollectionName;

            ConventionPack pack = new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);
        }
        public T AddCreationStamp(T entity)
        {
            entity.created = DateTime.UtcNow;
            entity.modified = entity.created;
            return entity;
        }
        public T AddUpdateStamp(T entity)
        {
            entity.modified = DateTime.UtcNow;
            return entity;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return GetCollection().AsQueryable();
        }
        public virtual T GetById(string id)
        {
            return GetCollection().AsQueryable().FirstOrDefault(record => record._id == id);
        }
        public virtual T Add(T entity)
        {
            if (string.IsNullOrEmpty(entity._id)) { entity._id = mongoDBService.GetUniqueMongoDatabaseIDForRecord(); }
            GetCollection().InsertOne(AddCreationStamp(entity));
            return entity;
        }
      
        public virtual T Update(T entity)
        {
            GetCollection().ReplaceOne<T>(record => record._id == entity._id, AddUpdateStamp(entity));
            return entity;
        }
       
        public virtual void Delete(string id)
        {
            GetCollection().DeleteOne<T>(record => record._id == id);
        }
        public IMongoCollection<T> GetCollection()
        {
            return mongoDBService.GetCollection<T>(COLLECTION_NAME);
        }
    }
}
