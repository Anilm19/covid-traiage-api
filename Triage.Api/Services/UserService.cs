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
        public User CreateUser(User user)
        {
            return _applicationUnitOfWork.Users.Add(user);
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
    }
}
