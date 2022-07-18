namespace Services.Abstract;

public interface IServiceManager
{
    ICommentService CommentService { get; }
    IPostService PostService { get; }
    IUserService UserService { get; }
}