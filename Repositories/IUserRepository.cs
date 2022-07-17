using Entities.Models;

namespace Repositories;

public interface IUserRepository
{
    Task<User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
    void Insert(User user);
    void Remove(User user);
}