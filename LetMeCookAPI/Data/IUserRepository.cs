using LetMeCookAPI.Models;

public interface IUserRepository
{
    User Add(User user);
    User Get(int id);
    int Delete(User user);
    int Update(User user);
}
