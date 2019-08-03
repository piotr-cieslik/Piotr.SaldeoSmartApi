using System;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests
{
    public sealed class ParametersTests
    {
        [Fact]
        public void ShouldBeImmutable()
        {
            var parameters1 = new Parameters();
            var parameters2 = parameters1.AddUsername("pc");

            Assert.Empty(parameters1);
            Assert.Single(parameters2);
        }

        [Fact]
        public void ShouldThrowExceptionWhenAddingSecondParameterWithSameKey()
        {
            var parameters =
                new Parameters()
                    .AddUsername("a");
            Assert.Throws<ArgumentException>(() => parameters.AddUsername("b"));
        }
    }
}
