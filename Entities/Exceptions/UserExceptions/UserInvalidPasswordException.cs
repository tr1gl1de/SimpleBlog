namespace Entities.Exceptions.UserExceptions;

public class UserInvalidPasswordException : ConflictException
{
    public UserInvalidPasswordException() : 
        base($"Incorrect password.")
    {
    }
}