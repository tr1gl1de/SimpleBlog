using Entities.Models;

namespace Repositories;

public interface IPostRepository
{
    Task<Post?> GetPostByIdAsync(Guid postId, CancellationToken cancellationToken = default);

    Task<IEnumerable<Post>> GetPostsAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Post>> GetPostsByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<IEnumerable<Post>> GetPostsByTagsAsync(List<string> tags, CancellationToken cancellationToken = default);

    Task<IEnumerable<Post>> GetPostsByNameAsync(string name, CancellationToken cancellationToken = default);

    void Insert(Post post);
    void Remove(Post post);
}