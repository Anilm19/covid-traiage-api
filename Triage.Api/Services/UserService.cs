using Models.DTO;
using Models.Entity;
using Models.Enum;
using MongoDB;
using System.Collections.Generic;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public UserService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public void AssignPatients(AssignPatientRequest request)
        {
          var user = _applicationUnitOfWork.Users.GetById(request.UserId);
            if(user!=null && user.IsActive)
            {
                foreach(var pat in request.PatientIds)
                {
                    _applicationUnitOfWork.PatientRelationshipRepository.AssignPatientToHealthWorker(pat, request.UserId);
                }
            }
        }

        public User CreateUser(User user)
        {
            return _applicationUnitOfWork.Users.Add(user);
        }

        public List<PatientDetails> GetAssignedPatients(string email)
        {
            var user = GetUserByEmail(email);
            if (user != null && user.Permission == UserPermission.HEALTHWORKER)
            {
                var patientList = _applicationUnitOfWork.PatientRelationshipRepository.GetPatientsAssignedForUser(user._id);
                List<PatientDetails> patientDetails = new List<PatientDetails>();
                foreach(var pat in patientList)
                {
                    var patdetatails = GetPatientDetails(pat);
                    if (patdetatails != null)
                    {
                        patientDetails.Add(patdetatails);
                    }
                }
                return patientDetails;
            }
            else
                throw new System.Exception("Unable to get patients !.");

        }

        public User GetUserByEmail(string email)
        {
            var user =  _applicationUnitOfWork.Users.GetUserByEmail(email);
            if (user != null){
                return user;
            }
            else
            {
                throw new System.Exception("No User Found !");
            }
        }

        public IEnumerable<User> GetUsersByPermission(UserPermission permission)
        {
            return _applicationUnitOfWork.Users.GetUsersByPermission(permission);
        }

        public User PromteToHealthWorker(string email)
        {
            var user = _applicationUnitOfWork.Users.GetUserByEmail(email);
            if (user != null)
            {
                user.Permission = Models.Enum.UserPermission.HEALTHWORKER;
                return _applicationUnitOfWork.Users.Update(user);
            }
            else
            {
                throw new System.Exception("No User Found !");
            }
        }


        private PatientDetails GetPatientDetails(string patientId)
        {
            var patient = _applicationUnitOfWork.Patient.GetById(patientId);
            if (patient != null)
            {
                PatientDetails details = new PatientDetails();
                details.Patient = patient;
                var triages = _applicationUnitOfWork.PatientTriage.GetTraigeByPatinetId(patientId);
                details.TriageDetails = triages;
                return details;
            }
            else
                return null;
        }
    }
}
