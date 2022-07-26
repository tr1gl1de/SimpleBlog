﻿using System;
using System.Threading.Tasks;
using Contracts.PostDto;
using Entities.Exceptions.CustomExceptions.PostExceptions;
using Entities.Models;
using EntityValidators;
using Moq;
using Repositories;
using Services;
using Services.Abstract;
using Xunit;

namespace Tests.ServicesTests.PostServiceTests.GetPostByIdTests;

public class GetPostByIdTests
{
    private readonly IPostService _postService;
    private readonly Mock<IRepositoryManager> _mockRepos;


    public GetPostByIdTests()
    {
        _mockRepos = new Mock<IRepositoryManager>();
        var validatorManager = new ValidatorManager();
        _postService = new PostService(_mockRepos.Object, validatorManager);
    }

    [Theory]
    [MemberData(nameof(GetPostByIdDataTests.GetValidGuids), MemberType = typeof(GetPostByIdDataTests))]
    public async Task GetPostById_InputValidGuid_ReturnPostForRead(Guid testGuid)
    {
        // Arrange
        var expectedPostForRead = new PostForReadDto()
        {
            Name = "test",
            Text = "Some text",
            UsernameCreator = "username",
            CreateDate = DateTime.UtcNow.Date
        };
        var returnedPost = new Post()
        {
            Id = testGuid,
            Name = expectedPostForRead.Name,
            Text = expectedPostForRead.Text,
            UsernameCreator = expectedPostForRead.UsernameCreator,
            CreateDate = DateTime.UtcNow.Date
        };
        _mockRepos.Setup(manager => manager.PostRepository.GetPostByIdAsync(testGuid, default))
            .ReturnsAsync(returnedPost);
        // Act
        var result = await _postService.GetPostByIdAsync(testGuid);
        // Assert
        TestUtils.AssertAllPropertiesEqual(expectedPostForRead, result);
    }

    [Theory]
    [MemberData(nameof(GetPostByIdDataTests.GetValidGuids), MemberType = typeof(GetPostByIdDataTests))]
    public async Task GetPostById_InputNotExistGuid_ReturnNotFoundException(Guid testGuid)
    {
        // Arrange

        _mockRepos.Setup(manager => manager.PostRepository.GetPostByIdAsync(testGuid, default))
            .ReturnsAsync((Post?) null);
        // Act
        Func<Task> throwingException = async () =>
        {
            await _postService.GetPostByIdAsync(testGuid);
        };
        // Assert
        await Assert.ThrowsAsync<PostNotFoundExceptions>(throwingException);
    }

    [Fact]
    public async Task GetPostById_InputEmptyGuid_ReturnNotFoundException()
    {
        // Arrange
        var testGuid = Guid.Empty;
        _mockRepos.Setup(manager => manager.PostRepository.GetPostByIdAsync(testGuid, default))
            .ReturnsAsync((Post?) null);
        // Act
        Func<Task> throwingException = async () =>
        {
            await _postService.GetPostByIdAsync(testGuid);
        };
        // Assert
        await Assert.ThrowsAsync<PostNotValidGuidException>(throwingException);
    }
}