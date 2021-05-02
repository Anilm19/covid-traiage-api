using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Models.Entity.Base
{
    public class BaseEntity
    {
        [BsonId]
        public string _id { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}
