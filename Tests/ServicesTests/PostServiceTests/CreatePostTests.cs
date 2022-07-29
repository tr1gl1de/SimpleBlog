using System;
using System.Collections.Generic;
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

namespace Tests.ServicesTests.PostServiceTests;

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

    [Fact]
    public async Task CreatePostAsync_InputPostForCreate_ReturnPostForReadType()
    {
        // Arrange
        var expectedUser = new UserForReadDto()
        {
            Username = "Username",
            Displayname = "displayName"
        };
        var expectedPostForCreate = new PostForCreationDto()
        {
            Name = "First post",
            Tags = new List<string>() { "other" },
            Text = "some text"
        };
        _mockRepos
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        _mockRepos
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        // Act
        var result = await _postService.CreatePostAsync(expectedPostForCreate, expectedUser);
        // Assert
        Assert.IsType<PostForReadDto>(result);
    }
    
    [Fact]
    public async Task CreatePostAsync_InputPostForCreate_ReturnPostForRead()
    {
        // Arrange
        var expectedUser = new UserForReadDto()
        {
            Username = "Username",
            Displayname = "displayName"
        };
        
        var expectedPostForCreate = new PostForCreationDto()
        {
            Name = "First post",
            Tags = new List<string>() { "other" },
            Text = "some text"
        };
        var expectedPostForRead = new PostForReadDto()
        {
            Name = expectedPostForCreate.Name,
            Tags = expectedPostForCreate.Tags,
            Text = expectedPostForCreate.Text,
            UsernameCreator = expectedUser.Username,
            CreateDate = DateTime.UtcNow.Date,
        };
        _mockRepos
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        _mockRepos
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        // Act
        var result = await _postService.CreatePostAsync(expectedPostForCreate, expectedUser);
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