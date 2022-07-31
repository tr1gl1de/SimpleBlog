using Entities.Exceptions.BaseExceptions;

namespace Entities.Exceptions.CustomExceptions.CommentExceptions;

public class CommentNotFoundException : NotFoundException
{
    public CommentNotFoundException(Guid commentId) : 
        base($"Comment with identifier \"{commentId}\" was not found.")
    {
    }
}