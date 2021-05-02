using Models.Entity;
using MongoDB.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System.Linq;

namespace MongoDB.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MongoDBService _mongoDBService) : base(_mongoDBService)
        {
            ConventionPack pack = new ConventionPack
                {
                    new EnumRepresentationConvention(BsonType.String)
                };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);
        }
        public override User Add(User entity)
        {
            var data = GetUserByEmail(entity.Email);
            if (data == null)
            {
                if (string.IsNullOrEmpty(entity._id)) { entity._id = mongoDBService.GetUniqueMongoDatabaseIDForRecord(); }
                GetCollection().InsertOne(AddCreationStamp(entity));
                return entity;
            }
            else
                return Update(entity);
        }
        public User GetUserByEmail(string email)
        {
            return GetCollection().AsQueryable().FirstOrDefault(usr => usr.Email.ToUpper() == email.ToUpper());
        }
    }
}
