using Models.Entity;

namespace Services
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
        User CreateUser(User user);
    }
}
