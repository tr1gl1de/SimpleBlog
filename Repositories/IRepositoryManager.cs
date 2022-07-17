namespace Repositories;

public interface IRepositoryManager
{
    IPostRepository PostRepository { get; }
    IUserRepository UserRepository { get; }
    ICommentRepository CommentRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}