using Entities.Exceptions.BaseExceptions;

namespace Entities.Exceptions.CustomExceptions.UserExceptions;

public class UserInvalidPasswordException : ConflictException
{
    public UserInvalidPasswordException() : 
        base($"Incorrect password.")
    {
    }
}