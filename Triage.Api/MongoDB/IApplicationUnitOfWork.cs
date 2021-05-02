using MongoDB.Repository;

namespace MongoDB
{
    public interface IApplicationUnitOfWork
    {
        IUserRepository Users { get; }
        IPatientRepository Patient { get; }
        IPatientTriageRepository PatientTriage { get; }
        IUserPatientRelationshipRepository PatientRelationshipRepository { get; }
    }
}
