using Models.Entity;
using MongoDB.Base;

namespace MongoDB.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
