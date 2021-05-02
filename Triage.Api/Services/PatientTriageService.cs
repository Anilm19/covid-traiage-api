using Models.Entity;
using MongoDB;
using System.Collections.Generic;

namespace Services
{
    public class PatientTriageService : IPatientTriageService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public PatientTriageService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }
        
        IEnumerable<PatientTriage> IPatientTriageService.GetTraigeByPatinetId(string patinetId)
        {
            return _applicationUnitOfWork.PatientTriage.GetTraigeByPatinetId(patinetId);
        }
    }
}
