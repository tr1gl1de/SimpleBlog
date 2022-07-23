using Contracts.PostDto;
using Entities.Models;
using Mapster;
using Repositories;
using Services.Abstract;

namespace Services;

public class PostService : IPostService
{
    private readonly IRepositoryManager _repositoryManager;

    public PostService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<PostForReadDto> CreatePostAsync(PostForCreationDto postForCreation, string usernameCreator,
        CancellationToken cancellationToken = default)
    {
        var post = postForCreation.Adapt<Post>();
        post.UsernameCreator = usernameCreator;
        _repositoryManager.PostRepository.Insert(post);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        return post.Adapt<PostForReadDto>();
    }

    public Task<PostForReadDto> GetPostByIdAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostForReadDto>> GetAllPostsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostForReadDto>> GetPostsByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostForReadDto>> GetPostsByTagsAsync(List<string> tags, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostForReadDto>> GetPostsByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePostByIdAsync(Guid postId, string usernameCreator, PostForUpdateDto postForUpdate,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeletePostByIdAsync(Guid postId, string usernameCreator, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}