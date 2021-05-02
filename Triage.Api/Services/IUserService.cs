using Models.DTO;
using Models.Entity;
using Models.Enum;
using System.Collections.Generic;

namespace Services
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
        User CreateUser(User user);
        User PromteToHealthWorker(string email);
        List<PatientDetails> GetAssignedPatients(string email);
        void AssignPatients(AssignPatientRequest request);
        IEnumerable<User> GetUsersByPermission(UserPermission permission);
    }
}
