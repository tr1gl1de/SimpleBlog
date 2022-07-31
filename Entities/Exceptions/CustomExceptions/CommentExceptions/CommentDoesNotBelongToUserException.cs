using Entities.Exceptions.BaseExceptions;

namespace Entities.Exceptions.CustomExceptions.CommentExceptions;

public class CommentDoesNotBelongToUserException : BadRequestException
{
    public CommentDoesNotBelongToUserException(Guid commentId, Guid userId) : 
        base($"The comment with identifier \"{commentId}\" does not belong to user with identifier \"{userId}\"")
    {
    }
    
    public CommentDoesNotBelongToUserException(Guid commentId, string username) : 
        base($"The comment with identifier \"{commentId}\" does not belong to user with username \"{username}\"")
    {
    }
}