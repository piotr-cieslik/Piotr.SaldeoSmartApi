using System;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests
{
    public sealed class TokenTests
    {
        [Fact]
        public void ShouldCreate()
        {
            new Token("1");
        }

        [Theory]
        [InlineData(default(string))]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldNotCreate(string value)
        {
            Assert.Throws<ArgumentException>(() => new Token(value));
        }
    }
}
