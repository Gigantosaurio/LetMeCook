using LetMeCookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace LetMeCookAPI.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User Get(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public int Delete(User user)
    {
        throw new NotImplementedException();
    }

    public int Update(User user)
    {
        throw new NotImplementedException();
    }
}
