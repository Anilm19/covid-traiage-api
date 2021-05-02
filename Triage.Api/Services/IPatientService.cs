using Models.DTO;
using Models.Entity;

namespace Services
{
    public interface IPatientService
    {
        Patient GetPatinetByICMRID(string email);
        PatientDetails GetPatientDetailsById(string id);
    }
}
