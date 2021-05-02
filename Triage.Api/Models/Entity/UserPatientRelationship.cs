using Models.Constants;
using Models.Entity.Base;
using MongoDB.Bson.Serialization.Attributes;
using Utility;


namespace Models.Entity
{
    [MongoCollectionNameAttribute(Table.USER_PATIENT_RELATIONSHIP_TABLE)]
    [BsonIgnoreExtraElements]
    public class UserPatientRelationship : BaseEntity
    {
        [BsonElement("userId")]
        public string UserId { get; set; }
        [BsonElement("patientId")]
        public string PatientId { get; set; }
    }
}
