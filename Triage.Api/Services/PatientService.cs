using Models.DTO;
using Models.Entity;
using MongoDB;

namespace Services
{
    public class PatientService : IPatientService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public PatientService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }
        public Patient GetPatinetByICMRID(string email)
        {
            return _applicationUnitOfWork.Patient.GetByICMRID(email);
        }

        public PatientDetails GetPatientDetailsById(string id)
        {
            var patient =  _applicationUnitOfWork.Patient.GetById(id);
            if (patient != null)
            {
                PatientDetails details = new PatientDetails();
                details.Patient = patient;
                var triages= _applicationUnitOfWork.PatientTriage.GetTraigeByPatinetId(id);
                details.TriageDetails = triages;
                return details;
            }
            else
                throw new System.Exception("No Patient Found !");
        }

        public void AssignHealthWorkerToPatient(string patientid, string userid)
        {
            _applicationUnitOfWork.PatientRelationshipRepository.AssignPatientToHealthWorker(patientid, userid);
        }
    }
}
