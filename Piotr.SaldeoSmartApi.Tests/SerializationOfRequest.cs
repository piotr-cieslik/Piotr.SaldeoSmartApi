using Piotr.SaldeoSmartApi.DataStructures;
using Piotr.SaldeoSmartApi.Serialization;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests
{
    public sealed class SerializationOfRequest
    {
        [Fact]
        public void NullValuesOfDocumentShouldNotBeSerialized()
        {
            var request =
                new Request
                {
                    Document = new Document(),
                };
            var xml =
                new XmlSerializer().Serialize(request);

            var expected =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<ROOT xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <DOCUMENT />
</ROOT>";
            Assert.Equal(expected, xml);
        }
    }
}
