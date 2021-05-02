using Models.Entity;
using Models.Enum;
using MongoDB.Base;
using System.Collections.Generic;

namespace MongoDB.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
        IEnumerable<User> GetUsersByPermission(UserPermission permission);
    }
}
