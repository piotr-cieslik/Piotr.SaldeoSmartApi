using Piotr.SaldeoSmartApi.Internal;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests.Internal
{
    /// <summary>
    /// Expected results taken from http://www.miraclesalad.com/webtools/md5.php
    /// </summary>
    public sealed class Md5OfStringTests
    {
        [Theory]
        [InlineData("", "D41D8CD98F00B204E9800998ECF8427E")]
        [InlineData("username=abc&req_id=0", "94C5237617DFA4E32998063FF8B0E7A6")]
        public void Hex(string value, string exected)
        {
            var hex = new Md5OfString(value);
            Assert.Equal(exected, hex);
        }
    }
}
