using Models.Entity;
using MongoDB.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Repository
{
    public interface IUserPatientRelationshipRepository : IRepository<UserPatientRelationship>
    {
        void AssignPatientToHealthWorker(string patientId, string userId);
    }
}
