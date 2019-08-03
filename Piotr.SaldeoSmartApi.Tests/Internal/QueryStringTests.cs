using System.Collections.Generic;
using Piotr.SaldeoSmartApi.Internal;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests.Internal
{
    public sealed class QueryStringTests
    {
        [Fact]
        public void ShouldReturnEmptyQueryStringWhenNoParameters()
        {
            var queryString =
                new QueryString(
                    new Dictionary<string, string>());
            Assert.Equal(string.Empty, queryString);
        }

        [Fact]
        public void ShouldReturnQuerySting()
        {
            var queryString =
                new QueryString(
                    new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    });
            Assert.Equal("?key1=value1&key2=value2", queryString);
        }
    }
}
