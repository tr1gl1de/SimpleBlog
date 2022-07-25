using System;
using Xunit;

namespace Tests;

internal static class TestUtils
{
    internal static void AssertAllPropertiesEqual<T>(T expectObject, T actualObject)
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