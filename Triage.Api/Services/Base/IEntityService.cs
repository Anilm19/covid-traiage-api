using Models.Entity.Base;
using System.Collections.Generic;

namespace Services
{
    public interface IEntityService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        T Add(T entity);
        T Update(T entity);
        void Delete(string id);
    }
}
