using Models.Constants;
using Models.Entity.Base;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Utility;


namespace Models.Entity
{
    [MongoCollectionNameAttribute(Table.USER_RELATIONSHIP_TABLE)]
    [BsonIgnoreExtraElements]
    class UserRelationships : BaseEntity
    {
        [BsonElement("userId")]
        public string UserId { get; set; }
        [BsonElement("assignedPatients")]
        public List<string> AssignedPatients { get; set; }
    }
}
