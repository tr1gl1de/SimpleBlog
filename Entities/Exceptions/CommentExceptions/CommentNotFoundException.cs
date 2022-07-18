namespace Entities.Exceptions.CommentExceptions;

public class CommentNotFoundException : NotFoundException
{
    public CommentNotFoundException(Guid commentId) : 
        base($"Comment with identifier \"{commentId}\" was not found.")
    {
    }
}