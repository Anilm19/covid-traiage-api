using MongoDB.Base;
using MongoDB.Repository;

namespace MongoDB
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly MongoDBService _mongoDBService;
        private IUserRepository _userRepository;
        private IPatientRepository _patientRepository;
        private IPatientTriageRepository _patientTriageRepository;
        private IUserPatientRelationshipRepository _userPatientRelationship;
        public ApplicationUnitOfWork(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        public IUserRepository Users => _userRepository ?? (_userRepository = new UserRepository(_mongoDBService));

        public IPatientRepository Patient => _patientRepository ?? (_patientRepository = new PatientRepository(_mongoDBService));

        public IPatientTriageRepository PatientTriage => _patientTriageRepository ?? (_patientTriageRepository = new PatientTriageRepository(_mongoDBService));

        public IUserPatientRelationshipRepository PatientRelationshipRepository => _userPatientRelationship ?? (_userPatientRelationship = new UserPatientRelationshipRepository(_mongoDBService));
    }
}
