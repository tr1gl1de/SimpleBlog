using Entities.Models;

namespace Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetCommentsByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Comment>> GetChildrenCommentsByIdCommentAsync(Guid commentId, CancellationToken cancellationToken = default);

    void Insert(Comment comment);
    void Remove(Comment comment);
}