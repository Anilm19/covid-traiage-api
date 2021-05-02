using Models.Constants;
using Models.Entity.Base;
using Models.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using Utility;

namespace Models.Entity
{
    [MongoCollectionNameAttribute(Table.USER_TABLE)]
    [BsonIgnoreExtraElements]
    public class User : BaseEntity
    {
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

        [BsonElement("Specialization")]
        public List<string> Specialization { get; set; }

        [BsonElement("preferedTimeSlots")]
        public List<string> PreferedTimeSlots { get; set; }

        [BsonElement("preferedDays")]
        public List<DayInWeek> PreferedDays { get; set; }

        [BsonElement("languages")]
        public List<Languages> Languages { get; set; }

        [BsonElement("remoteWork")]
        public bool RemoteWork { get; set; }

        [BsonElement("fieldWork")]
        public bool FieldWork { get; set; }
        [BsonElement("ndaSigned")]
        public bool NDASigned { get; set; }
        [BsonElement("orientationDone")]
        public bool OrientationDone { get; set; }
        [BsonElement("isActive")]
        public bool IsActive { get; set; }
        [BsonElement("permission")]
        public UserPermission Permission { get; set; }    
    }

    public class Address
    {
        [BsonElement("lineAddress")]
        public string LineAddress { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("wardNumber")]
        public string WardNumber { get; set; }
        [BsonElement("zone")]
        public string Zone { get; set; }
        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("pinCode")]
        public string PinCode { get; set; }
    }
}
