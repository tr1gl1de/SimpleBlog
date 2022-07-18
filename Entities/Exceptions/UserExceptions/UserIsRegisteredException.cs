namespace Entities.Exceptions.UserExceptions;

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