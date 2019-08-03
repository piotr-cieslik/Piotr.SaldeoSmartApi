using Piotr.SaldeoSmartApi.Internal;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests.Internal
{
    public sealed class UrlEncodedStringTests
    {
        [Theory]
        [InlineData("A", "A")]
        [InlineData("B", "B")]
        [InlineData("C", "C")]
        [InlineData("D", "D")]
        [InlineData("a", "a")]
        [InlineData("b", "b")]
        [InlineData("c", "c")]
        [InlineData("d", "d")]
        [InlineData("1", "1")]
        [InlineData("2", "2")]
        [InlineData("3", "3")]
        [InlineData(" ", "+")]
        [InlineData("!", "%21")]
        [InlineData("\"", "%22")]
        [InlineData("#", "%23")]
        [InlineData("$", "%24")]
        [InlineData("%", "%25")]
        [InlineData("&", "%26")]
        [InlineData("'", "%27")]
        [InlineData("(", "%28")]
        [InlineData(")", "%29")]
        [InlineData("*", "*")]
        [InlineData("+", "%2B")]
        [InlineData(",", "%2C")]
        [InlineData("-", "-")]
        [InlineData(".", ".")]
        [InlineData("/", "%2F")]
        [InlineData(":", "%3A")]
        [InlineData(";", "%3B")]
        [InlineData("<", "%3C")]
        [InlineData("=", "%3D")]
        [InlineData(">", "%3E")]
        [InlineData("?", "%3F")]
        [InlineData("@", "%40")]
        [InlineData("[", "%5B")]
        [InlineData("]", "%5D")]
        [InlineData("^", "%5E")]
        [InlineData("_", "_")]
        [InlineData("`", "%60")]
        [InlineData("{", "%7B")]
        [InlineData("|", "%7C")]
        [InlineData("}", "%7D")]
        [InlineData("~", "%7E")]
        [InlineData("Ł", "%C5%81")]
        [InlineData("ł", "%C5%82")]
        [InlineData("Ó", "%C3%93")]
        [InlineData("ó", "%C3%B3")]
        [InlineData("€", "%E2%82%AC")]
        [InlineData("Ā", "%C4%80")]
        public void ShouldEncodeSingleCharacter(string value, string expected)
        {
            var actual = new UrlEncodedString(value);
            Assert.Equal(expected, actual);
        }
    }
}
