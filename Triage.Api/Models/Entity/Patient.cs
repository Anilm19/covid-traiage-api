using Models.Constants;
using Models.Entity.Base;
using Models.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using Utility;

namespace Models.Entity
{
    [MongoCollectionNameAttribute(Table.PATIENT_TABLE)]
    [BsonIgnoreExtraElements]
    public class Patient : BaseEntity
    {
        [BsonElement("icmrid")]
        public string ICMRID { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("gender")]
        public Gender Gender { get; set; }

        [BsonElement("birthDate")]
        public DateTime? BirthDate { get; set; }
        [BsonElement("mobileNumber")]
        public string MobileNumber { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }
    }
}
