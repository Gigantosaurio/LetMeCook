using LetMeCookAPI.Models;
using LetMeCookAPI.Data;

namespace LetMeCookAPI.Services;
public class UsersService
{
    private readonly UserRepository _repository;
    public UsersService(UserRepository repository)
    {
        _repository = repository;
    }

    public User GetUserById(int id)
    {
        return _repository.Get(id);
    }

    public User CreateUser(User user)
    {
        return _repository.Add(user);
    }
}