namespace Entities.Exceptions.PostExceptions;

public class PostDoesNotBelongToUserException : BadRequestException
{
    public PostDoesNotBelongToUserException(Guid postId, Guid userId) : 
        base($"The post with identifier \"{postId}\" does not belong to the user with the identifier \"{userId}\".")
    {
    }
    
    public PostDoesNotBelongToUserException(Guid postId, string username) : 
        base($"The post with identifier \"{postId}\" does not belong to the user with the username \"{username}\".")
    {
    }
}