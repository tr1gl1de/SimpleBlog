using Contracts.PostDto;

namespace Services.Abstract;

public interface IPostService
{
    Task<PostForReadDto> CreatePostAsync(PostForCreationDto postForCreation, string usernameCreator, CancellationToken cancellationToken = default);
    Task<PostForReadDto> GetPostByIdAsync(Guid postId, CancellationToken cancellationToken = default);
    Task<IEnumerable<PostForReadDto>> GetAllPostsAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<PostForReadDto>> GetPostsByUsernameAsync(string username,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<PostForReadDto>> GetPostsByTagsAsync(List<string> tags,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<PostForReadDto>> GetPostsByNameAsync(string name, CancellationToken cancellationToken = default);

    Task UpdatePostByIdAsync(Guid postId, string usernameCreator,PostForUpdateDto postForUpdate, CancellationToken cancellationToken = default);

    Task DeletePostByIdAsync(Guid postId, string usernameCreator,CancellationToken cancellationToken = default);
}