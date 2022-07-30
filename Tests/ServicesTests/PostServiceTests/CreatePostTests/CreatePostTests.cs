using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts.PostDto;
using Contracts.UserDto;
using Entities.Models;
using EntityValidators;
using Moq;
using Repositories;
using Services;
using Services.Abstract;
using Xunit;

namespace Tests.ServicesTests.PostServiceTests.CreatePostTests;

public class CreatePostTests
{
    private readonly IPostService _postService;
    private readonly Mock<IRepositoryManager> _mockRepos;

    public CreatePostTests()
    {
        _mockRepos = new Mock<IRepositoryManager>();
        var validatorManager = new ValidatorManager();
        _postService = new PostService(_mockRepos.Object, validatorManager);
    }

    [Theory]
    [MemberData(nameof(CreatePostDataTests.GetValidPostAndUser), MemberType = typeof(CreatePostDataTests))]
    public async Task CreatePostAsync_InputPostForCreate_ReturnPostForReadType(PostForCreationDto expectPost,
        UserForReadDto expectUser)
    {
        // Arrange
        _mockRepos
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        _mockRepos
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        // Act
        var result = await _postService.CreatePostAsync(expectPost, expectUser);
        // Assert
        Assert.IsType<PostForReadDto>(result);
    }
    
    [Theory]
    [MemberData(nameof(CreatePostDataTests.GetValidPostAndUser), MemberType = typeof(CreatePostDataTests))]
    public async Task CreatePostAsync_InputPostForCreate_ReturnPostForRead(PostForCreationDto expectPost,
        UserForReadDto expectUser)
    {
        // Arrange
        var expectedPostForRead = new PostForReadDto()
        {
            Name = expectPost.Name,
            Tags = expectPost.Tags,
            Text = expectPost.Text,
            UsernameCreator = expectUser.Username,
            CreateDate = DateTime.UtcNow.Date,
        };
        _mockRepos
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        _mockRepos
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        // Act
        var result = await _postService.CreatePostAsync(expectPost, expectUser);
        result.CreateDate = result.CreateDate.Date;
        // Assert
        TestUtils.AssertAllPropertiesEqual(expectedPostForRead, result);
    }

    [Theory]
    [MemberData(nameof(CreatePostDataTests.GetInvalidPostAndValidUser), MemberType = typeof(CreatePostDataTests))]
    public async Task CreatePostAsync_InputPostForCreateEmpty_ReturnValidateException(PostForCreationDto expectedPost,
        UserForReadDto expectedUser)
    {
        _mockRepos
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        _mockRepos
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        // Act
        Func<Task> throwingAction = async () =>
        {
            await _postService.CreatePostAsync(expectedPost, expectedUser);
        };
        
        // Assert
        await Assert.ThrowsAsync<FluentValidation.ValidationException>(throwingAction);
    }

    [Theory]
    [MemberData(nameof(CreatePostDataTests.GetInvalidUserAndValidPost), MemberType = typeof(CreatePostDataTests))]
    public async Task CreatePostAsync_InputPostForCreateWithEmptyUsername_ReturnValidateException(PostForCreationDto expectedPost,
        UserForReadDto expectedUser)
    {
        _mockRepos
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        _mockRepos
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        // Act
        Func<Task> throwingAction = async () =>
        {
            await _postService.CreatePostAsync(expectedPost, expectedUser);
        };
        
        // Assert
        await Assert.ThrowsAsync<FluentValidation.ValidationException>(throwingAction);
    }
}