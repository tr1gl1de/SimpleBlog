using Entities.Exceptions.BaseExceptions;

namespace Entities.Exceptions.CustomExceptions.PostExceptions;

public sealed class PostNotFoundExceptions : NotFoundException
{
    public PostNotFoundExceptions(string name) : 
        base($"Post with name \"{name}\" was not found.")
    {
    }
    
    public PostNotFoundExceptions(Guid postId) : 
        base($"Post with identifier \"{postId}\" was not found.")
    {}
}