namespace Entities.Exceptions.BaseExceptions;

public abstract class ConflictException : Exception
{
    protected ConflictException(string message) : base(message)
    {}
}