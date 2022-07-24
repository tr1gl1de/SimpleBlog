using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts.PostDto;
using Entities.Models;
using Moq;
using Repositories;
using Services;
using Xunit;

namespace Tests.ServicesTests;

public class PostServiceTests
{

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
        var repositoryMock = new Mock<IRepositoryManager>();
        repositoryMock
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        repositoryMock
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        var fakePostService = new PostService(repositoryMock.Object);
        // Act
        var result = await fakePostService.CreatePostAsync(expectedPostForCreate, expectedUsername);
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
            // Name = "not valid name",
            Tags = expectedPostForCreate.Tags,
            Text = expectedPostForCreate.Text,
            UsernameCreator = expectedUsername,
            CreateDate = DateTime.UtcNow.Date,
        };
        var repositoryMock = new Mock<IRepositoryManager>();
        repositoryMock
            .Setup(manager => manager.PostRepository.Insert(It.IsAny<Post>()));
        repositoryMock
            .Setup(manager => manager.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));
        var fakePostService = new PostService(repositoryMock.Object);
        // Act
        var result = await fakePostService.CreatePostAsync(expectedPostForCreate, expectedUsername);
        result.CreateDate = result.CreateDate.Date;
        // Assert
        AssertAllPropertiesEqual(expectedPostForRead, result);
    }

    
    private void AssertAllPropertiesEqual<T>(T expectObject, T actualObject)
    {
        Type type = typeof(T);

        var propertiesInfoOfType = type.GetProperties();

        foreach (var prop in propertiesInfoOfType)
        {
            if (prop.GetIndexParameters().Length == 0)
            {
                var propActualObjValue = prop.GetValue(actualObject);
                var propExpectObjValue = prop.GetValue(expectObject);
                
                Assert.Equal(propExpectObjValue, propActualObjValue);
            }
        }
    }
}