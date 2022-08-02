namespace Entities.Exceptions.BaseExceptions;

public class InvalidArgException : Exception
{
    protected InvalidArgException(string message) : base(message)
    {}
}