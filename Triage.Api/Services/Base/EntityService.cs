using Models.Entity.Base;
using MongoDB.Base;

namespace Services
{
    public class EntityService<T> : GenericRepository<T>, IEntityService<T> where T : BaseEntity
    {
        public EntityService(MongoDBService _mongoDBService) : base(_mongoDBService)
        {

        }
    }
}
