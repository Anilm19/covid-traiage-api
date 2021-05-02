using Models.Entity;
using MongoDB.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Repository
{

    public class PatientTriageRepository : GenericRepository<PatientTriage>, IPatientTriageRepository
    {
        public PatientTriageRepository(MongoDBService _mongoDBService) : base(_mongoDBService)
        {
            ConventionPack pack = new ConventionPack
                {
                    new EnumRepresentationConvention(BsonType.String)
                };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);
        }

        public IEnumerable<PatientTriage> GetTraigeByPatinetId(string patinetId)
        {
            return GetCollection().AsQueryable().Where(usr => usr.PatientId.ToUpper() == patinetId.ToUpper());
        }
    }
}
