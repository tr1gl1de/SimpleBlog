using System;
using System.Collections.Generic;

namespace Tests.ServicesTests.PostServiceTests.GetPostByIdTests;

internal static class GetPostByIdDataTests
{
    private static readonly IEnumerable<Guid> _validGuids = GeneratorValidGuid(3);
    
    private static IEnumerable<Guid> GeneratorValidGuid(int lenght)
    {
        var result = new List<Guid>();
        
        for (int i = 0; i < lenght; i++)
        {
            result.Add(Guid.NewGuid());
        }

        return result;
    }

    public static IEnumerable<object[]> GetValidGuids()
    {
        foreach (var validGuid in _validGuids)
        {
            yield return new object[]
            {
                validGuid
            };
        }
    }
}