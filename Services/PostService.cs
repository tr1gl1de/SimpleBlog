using Contracts.PostDto;
using Contracts.UserDto;
using Entities.Models;
using EntityValidators;
using FluentValidation;
using Mapster;
using Repositories;
using Services.Abstract;

namespace Services;

public class PostService : IPostService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ValidatorManager _validatorManager;

    public PostService(IRepositoryManager repositoryManager, ValidatorManager validatorManager)
    {
        _repositoryManager = repositoryManager;
        _validatorManager = validatorManager;
    }
    
    public async Task<PostForReadDto> CreatePostAsync(PostForCreationDto postForCreation, UserForReadDto user,
        CancellationToken cancellationToken = default)
    {
        await _validatorManager.PostForCreateValidator.ValidateAndThrowAsync(postForCreation, cancellationToken);
        var post = postForCreation.Adapt<Post>();
        post.UsernameCreator = user.Username;
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