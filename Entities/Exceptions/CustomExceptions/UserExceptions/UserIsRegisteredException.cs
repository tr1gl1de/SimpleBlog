using Entities.Exceptions.BaseExceptions;

namespace Entities.Exceptions.CustomExceptions.UserExceptions;

public sealed class UserIsRegisteredException : ConflictException
{
    public UserIsRegisteredException(string username) : 
        base($"Username \"{username}\" already taken.")
    {
    }
    public UserIsRegisteredException() : 
        base($"Username already taken.")
    {
    }
}