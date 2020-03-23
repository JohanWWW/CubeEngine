using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Extensions
{
    public static class Assertions
    {
        public static void ShouldHaveValue<T>(this T actualValue, T expectedValue) => 
            Assert.Equal(expectedValue, actualValue);
    }
}
