using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests
{
    /// <summary>
    /// Tests check if properties of data structure
    /// match name of XML element converted to standard C# convention.
    /// "DOCUMENT" => "Document"
    /// "DOCUMENT_ID" => "DocumentId"
    /// </summary>
    public sealed class NamingConventionTests
    {
        [Theory]
        [MemberData(nameof(ShouldPropertyHasCorrectNameData))]
        public void ShouldPropertyNameMatchNamingConvention(Type type)
        {
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                    var attribute =
                        property.CustomAttributes
                            .Where(
                                x =>
                                    x.AttributeType == typeof(XmlArrayAttribute) ||
                                    x.AttributeType == typeof(XmlElementAttribute))
                            .Single();
                    var xmlElmentName =
                        attribute.ConstructorArguments[0].Value as string;
                    var expectedPropertyName =
                        ExpectedPropertyName(xmlElmentName);

                    Assert.Equal(expectedPropertyName, property.Name);
            }
        }

        public static IEnumerable<object[]> ShouldPropertyHasCorrectNameData
        {
            get
            {
                var dataStructure = typeof(DataStructures.Article);
                return dataStructure.Assembly
                    .GetTypes()
                    .Where(x => x.IsClass)
                    .Where(x => x.Namespace == dataStructure.Namespace)
                    .Select(x => new object[] { x });
            }
        }

        [Theory]
        [InlineData("DOCUMENT", "Document")]
        [InlineData("DOCUMENT_ID", "DocumentId")]
        [InlineData("COUNTRY_ISO3166A2", "CountryISO3166A2")]
        public void ShouldReturnExpectedPropertyName(string actual, string expected)
        {
            var result = ExpectedPropertyName(actual);
            Assert.Equal(expected, result);
        }

        private string ExpectedPropertyName(string xmlElementName)
        {
            var words = xmlElementName.Split("_");
            var propertyName = new StringBuilder();
            foreach(var word in words)
            {
                if (word.StartsWith("ISO"))
                {
                    propertyName.Append(word);
                    continue;
                }

                propertyName.Append(char.ToUpper(word[0]) + word.Substring(1).ToLower());
            }
            return propertyName.ToString();
        }
    }
}