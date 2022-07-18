namespace Entities.Exceptions.UserExceptions;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid userId) : 
        base($"User with identifier {userId} was not found.")
    {}
    public UserNotFoundException(string username) : 
        base($"User with username \"{username}\" was not found.")
    {}
}