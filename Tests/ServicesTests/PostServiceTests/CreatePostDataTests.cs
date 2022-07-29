using System.Collections.Generic;
using System.Linq;
using Bogus;
using Contracts.PostDto;
using Contracts.UserDto;

namespace Tests.ServicesTests.PostServiceTests;

internal static class CreatePostDataTests
{
    private static readonly Faker Faker = new("en");

    private static IEnumerable<UserForReadDto> ValidUserForRead { get; } = new List<UserForReadDto>()
    {
        new()
        {
            Username = Faker.Internet.UserName(),
            Displayname = Faker.Name.FirstName()
        },
        new()
        {
            Username = Faker.Internet.UserName(),
            Displayname = Faker.Name.FirstName()
        },
        new()
        {
            Username = Faker.Internet.UserName(),
            Displayname = Faker.Name.FirstName()
        },
        new()
        {
            Username = Faker.Internet.UserName(),
            Displayname = Faker.Name.FirstName()
        },
        new()
        {
            Username = Faker.Internet.UserName(),
            Displayname = Faker.Name.FirstName()
        }
    };

    private static IEnumerable<PostForCreationDto> ValidPostForCreation { get; } = new List<PostForCreationDto>()
    {
        new()
        {
            Name = Faker.Lorem.Sentence(3),
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = Faker.Lorem.Sentences(3)
        },
        new()
        {
            Name = Faker.Lorem.Sentence(3),
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = Faker.Lorem.Sentences(3)
        },
        new()
        {
            Name = Faker.Lorem.Sentence(3),
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = Faker.Lorem.Sentences(3)
        },
        new()
        {
            Name = Faker.Lorem.Sentence(3),
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = Faker.Lorem.Sentences(3)
        },
        new()
        {
            Name = Faker.Lorem.Sentence(3),
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = Faker.Lorem.Sentences(3)
        }
    };

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
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = Faker.Lorem.Sentences(3)
        },
        new()
        {
            Name  = null,
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = Faker.Lorem.Sentences(3) 
        },
        new()
        {
            Name  = Faker.Lorem.Sentence(2),
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = ""
        },
        new()
        {
            Name  = Faker.Lorem.Sentence(2),
            Tags = Faker.Commerce.Categories(2).ToList(),
            Text = null
        },
        new()
        {
            Name = Faker.Lorem.Sentence(2),
            Tags = Faker.Commerce.Categories(11).ToList(),
            Text = Faker.Lorem.Sentences(3)
        }
        
    };

    
    public static IEnumerable<object[]> GetInvalidUserAndValidPost()
    {
        // if (ValidPostForCreation.Count() != ValidUserForRead.Count())
        // {
        //     yield break;
        // }
        foreach ((PostForCreationDto post, UserForReadDto user) in ValidPostForCreation.Zip(NullAndEmptyUser))
        {
            yield return new object[]
            {
                post, user
            };
        }
    }

    public static IEnumerable<object[]> GetInvalidPostAndValidUser()
    {
        foreach ((PostForCreationDto post, UserForReadDto user) in NullAndEmptyPost.Zip(ValidUserForRead))
        {
            yield return new object[]
            {
                post, user
            };
        }
    }
}