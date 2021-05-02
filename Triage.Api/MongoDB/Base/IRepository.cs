using Models.Entity.Base;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDB.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        T Add(T entity);
        T Update(T entity);
        void Delete(string id);
        T AddCreationStamp(T entity);
        T AddUpdateStamp(T entity);
        IMongoCollection<T> GetCollection();
    }
}
