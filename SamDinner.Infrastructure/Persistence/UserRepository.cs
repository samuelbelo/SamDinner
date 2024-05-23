using SamDinner.Application.Common.Interfaces.Persistence;
using SamDinner.Domain.Entities;

namespace SamDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository 
{

    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
