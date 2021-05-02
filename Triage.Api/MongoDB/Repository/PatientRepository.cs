using Models.Constants;
using Models.DTO;
using Models.Entity;
using MongoDB.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System.Linq;

namespace MongoDB.Repository
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(MongoDBService _mongoDBService) : base(_mongoDBService)
        {
            ConventionPack pack = new ConventionPack
                {
                    new EnumRepresentationConvention(BsonType.String)
                };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);
        }
        public Patient GetByICMRID(string icmrid)
        {
            return GetCollection().AsQueryable().FirstOrDefault(usr => usr.ICMRID.ToUpper() == icmrid.ToUpper());
        }

    }
}
