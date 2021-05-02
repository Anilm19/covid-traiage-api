using Models.Entity;
using MongoDB;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public UserService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public User CreateUser(User user)
        {
            return _applicationUnitOfWork.Users.Add(user);
        }

        public User GetUserByEmail(string email)
        {
            return _applicationUnitOfWork.Users.GetUserByEmail(email);
        }
    }
}
