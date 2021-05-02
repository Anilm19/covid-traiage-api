using Models.Entity;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Models.DTO
{
    public class PatientDetails
    {
        public Patient Patient { get; set; }
        public IEnumerable<PatientTriage> TriageDetails { get; set; }
    }
}
