using System.Collections.Generic;
using System.Linq;
using Bogus;
using Contracts.PostDto;
using Contracts.UserDto;

namespace Tests.ServicesTests.PostServiceTests.CreatePostTests;

internal enum Counts
{
    PostName = 2,
    PostTextSentences = 3,
    PostTags = 2
}

internal static class CreatePostDataTests
{
    private static readonly Faker Faker = new("en");
    
    #region Methods

    private static IEnumerable<UserForReadDto> GeneratorValidUserForRead(int lenght)
    {
        var result = new List<UserForReadDto>();
        for (int i = 0; i < lenght; i++)
        {
            result.Add(new UserForReadDto()
            {
                Username = Faker.Internet.UserName(),
                Displayname = Faker.Name.FirstName()
            });
        }

        return result;
    }
    
    private static IEnumerable<PostForCreationDto> GeneratorValidPostForCreation(int lenght)
    {
        var result = new List<PostForCreationDto>();
        for (int i = 0; i < lenght; i++)
        {
            result.Add(new PostForCreationDto()
            {
                Name = Faker.Lorem.Sentence((int)Counts.PostName),
                Tags = Faker.Commerce.Categories((int)Counts.PostTags).ToList(),
                Text = Faker.Lorem.Sentences((int)Counts.PostTextSentences)
            });
        }

        return result;
    }
    #endregion


    #region Properties

    private static IEnumerable<UserForReadDto> ValidUserForRead { get; } = GeneratorValidUserForRead(5);

    private static IEnumerable<PostForCreationDto> ValidPostForCreation { get; } = GeneratorValidPostForCreation(5);

    private static IEnumerable<UserForReadDto> NullAndEmptyUser { get; } = new List<UserForReadDto>()
    {
        new()
        {
            Username = "",
            Displayname = ""
        },
        new()
        {
            Username = null,
            Displayname = ""
        },
        new()
        {
            Username  = "",
            Displayname = null
        },
        new()
        {
            Username = null,
            Displayname = null
        },
    };

    private static IEnumerable<PostForCreationDto> NullAndEmptyPost { get; } = new List<PostForCreationDto>()
    {
        new()
        {
            Name = "",
            Tags = Faker.Commerce.Categories((int)Counts.PostTags).ToList(),
            Text = Faker.Lorem.Sentences((int)Counts.PostTextSentences)
        },
        new()
        {
            Name  = null,
            Tags = Faker.Commerce.Categories((int)Counts.PostTags).ToList(),
            Text = Faker.Lorem.Sentences((int)Counts.PostTextSentences) 
        },
        new()
        {
            Name  = Faker.Lorem.Sentence((int)Counts.PostName),
            Tags = Faker.Commerce.Categories((int)Counts.PostTags).ToList(),
            Text = ""
        },
        new()
        {
            Name  = Faker.Lorem.Sentence((int)Counts.PostName),
            Tags = Faker.Commerce.Categories((int)Counts.PostTags).ToList(),
            Text = null
        },
        new()
        {
            Name = Faker.Lorem.Sentence(4),
            Tags = Faker.Commerce.Categories(11).ToList(),
            Text = Faker.Lorem.Sentences(3)
        }
        
    };

    #endregion
    
    // in all iterators use equal lenght of zipping objects
    #region Iterators
    public static IEnumerable<object[]> GetValidPostAndUser()
    {
        foreach (var (post, user) in ValidPostForCreation.Zip(ValidUserForRead))
        {
            yield return new object[]
            {
                post, user
            };
        }
    }

    public static IEnumerable<object[]> GetInvalidUserAndValidPost()
    {
        foreach (var (post, user) in ValidPostForCreation.Zip(NullAndEmptyUser))
        {
            yield return new object[]
            {
                post, user
            };
        }
    }

    public static IEnumerable<object[]> GetInvalidPostAndValidUser()
    {
        foreach (var (post, user) in NullAndEmptyPost.Zip(ValidUserForRead))
        {
            yield return new object[]
            {
                post, user
            };
        }
    }
    #endregion
}