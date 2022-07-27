﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts.PostDto;
using Entities.Models;
using EntityValidators;
using Moq;
using Repositories;
using Services;
using Services.Abstract;
using Xunit;

namespace Tests.ServicesTests;

public class PostServiceTests
{
    private readonly IPostService _postService;
    private readonly Mock<IRepositoryManager> _mockRepos;

    public PostServiceTests()
    {
        _mockRepos = new Mock<IRepositoryManager>();
        var validatorManager = new ValidatorManager();
        _postService = new PostService(_mockRepos.Object, validatorManager);
    }

    [Fact]
    public async Task CreatePostAsync_InputPostForCreate_ReturnPostForReadType()
    {
        // Arrange
        string expectedUsername = "username";
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
        var result = await _postService.CreatePostAsync(expectedPostForCreate, expectedUsername);
        // Assert
        Assert.IsType<PostForReadDto>(result);
    }
    
    [Fact]
    public async Task CreatePostAsync_InputPostForCreate_ReturnPostForRead()
    {
        // Arrange
        string expectedUsername = "username";
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
            UsernameCreator = expectedUsername,
            CreateDate = DateTime.UtcNow.Date,
        };
        _mockRepos
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        _mockRepos
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        // Act
        var result = await _postService.CreatePostAsync(expectedPostForCreate, expectedUsername);
        result.CreateDate = result.CreateDate.Date;
        // Assert
        TestUtils.AssertAllPropertiesEqual(expectedPostForRead, result);
    }

    [Fact]
    public async Task CreatePostAsync_InputPostForReadCreateEmpty_ReturnValidateException()
    {
        // Arrange
        string expectedUsername = "";
        var expectedPostForCreate = new PostForCreationDto()
        {
            Name = "",
            Tags = new List<string>() { "" },
            Text = ""
        };
        _mockRepos
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        _mockRepos
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        // Act
        Func<Task> throwingAction = async () =>
        {
            await _postService.CreatePostAsync(expectedPostForCreate, expectedUsername);
        };
        
        // Assert
        await Assert.ThrowsAsync<FluentValidation.ValidationException>(throwingAction);
    }
}