using Models.Entity;
using MongoDB.Base;
using System.Collections.Generic;

namespace MongoDB.Repository
{
    public interface IPatientTriageRepository : IRepository<PatientTriage>
    {
        IEnumerable<PatientTriage> GetTraigeByPatinetId(string patinetId);
    }
}
