using Models.Constants;
using Models.Entity.Base;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using Utility;

namespace Models.Entity
{
    [MongoCollectionNameAttribute(Table.PATIENT_TRIAGE_TABLE)]
    [BsonIgnoreExtraElements]
    public class PatientTriage : BaseEntity
    {
        [BsonElement("patientId")]
        public string PatientId { get; set; }
        [BsonElement("date")]
        public DateTime? Date { get; set; }
        [BsonElement("ward")]
        public string Ward { get; set; }
        [BsonElement("isWardConfirmed")]
        public bool IsWardConfirmed { get; set; }
        [BsonElement("HomeIsolation")]
        public string HomeIsolation { get; set; }
        [BsonElement("attendedBy")]
        public string AttendedBy { get; set; }
        [BsonElement("callStatus")]
        public string CallStatus { get; set; }
        [BsonElement("isAsymptomatic")]
        public bool IsAsymptomatic { get; set; }
        [BsonElement("symptoms")]
        public List<string> Symptoms { get; set; }
        [BsonElement("symptomsLevel")]
        public string SymptomsLevel { get; set; }
        [BsonElement("comorbidities")]
        public string Comorbidities { get; set; }
        [BsonElement("comorbiditiesRemarks")]
        public string ComorbiditiesRemarks { get; set; }
        [BsonElement("otherMedicalRemarks")]
        public string OtherMedicalRemarks { get; set; }
        [BsonElement("spo2")]
        public string SPO2 { get; set; }
        [BsonElement("respiratoryrate")]
        public string RespiratoryRate { get; set; } 
        [BsonElement("temparature")]
        public string Temparature { get; set; }
        [BsonElement("familyMembersCount")]
        public string FamilyMembersCount { get; set; }
        [BsonElement("roomAvailable")]
        public bool RoomAvailable { get; set; }
        [BsonElement("caregiverAvailability")]
        public bool CaregiverAvailability { get; set; }
        [BsonElement("seperateIsolatedRoom")]
        public bool SeperateIsolatedRoom { get; set; }
        [BsonElement("eligibleForHomeQuarantine")]
        public bool EligibleForHomeQuarantine { get; set; }
        [BsonElement("toBeShiftedToCCC")]
        public bool ToBeShiftedToCCC { get; set; }
        [BsonElement("toBeShiftedToHospital")]
        public bool ToBeShiftedToHospital { get; set; }
        [BsonElement("otherStatus")]
        public string OtherStatus { get; set; }
        [BsonElement("admittedOn")]
        public DateTime? AdmittedOn { get; set; }
        [BsonElement("bedCategory")]
        public string BedCategory { get; set; }
        [BsonElement("admittedHospital")]
        public string AdmittedHospital { get; set; }
        [BsonElement("isDead")]
        public bool IsDead { get; set; }
        [BsonElement("dateOfDeath")]
        public DateTime? DateOfDeath { get; set; }
        [BsonElement("placeOfDeath")]
        public string PlaceOfDeath { get; set; }
        [BsonElement("remarks")]
        public string Remarks { get; set; }
    }
}
