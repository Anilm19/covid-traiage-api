using Models.Entity;
using MongoDB.Base;
using System.Collections.Generic;

namespace MongoDB.Repository
{
    public interface IUserPatientRelationshipRepository : IRepository<UserPatientRelationship>
    {
        void AssignPatientToHealthWorker(string patientId, string userId);
        IEnumerable<string> GetPatientsAssignedForUser(string userId);
    }
}
