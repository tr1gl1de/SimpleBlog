using Entities.Exceptions.BaseExceptions;

namespace Entities.Exceptions.CustomExceptions.PostExceptions;

public class PostNotValidGuidException : InvalidArgException
{
    public PostNotValidGuidException()
        : base($"Guid can not be empty")
    {
    }
}