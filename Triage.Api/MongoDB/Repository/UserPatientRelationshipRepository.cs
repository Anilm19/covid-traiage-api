using Models.Entity;
using MongoDB.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System.Linq;


namespace MongoDB.Repository
{
    public class UserPatientRelationshipRepository : GenericRepository<UserPatientRelationship>, IUserPatientRelationshipRepository
    {
        public UserPatientRelationshipRepository(MongoDBService _mongoDBService) : base(_mongoDBService)
        {
            ConventionPack pack = new ConventionPack
                {
                    new EnumRepresentationConvention(BsonType.String)
                };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);
        }

        public void AssignPatientToHealthWorker(string patientId, string userId)
        {
            var pat=  GetCollection().AsQueryable().Where(usr => usr.PatientId == patientId);
            if (pat == null)
            {
                var data = new UserPatientRelationship();
                data._id = mongoDBService.GetUniqueMongoDatabaseIDForRecord();
                data.PatientId = patientId;
                data.UserId = userId;
                Add(data);
            }
            else if(pat.Count() == 1){
                var data = pat.First();
                data.UserId = userId;
                Update(data);
            }
        }
    }
}
