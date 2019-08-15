using System;
using System.Collections.Generic;
using System.Linq;
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
        public void ShouldReturnExpectedPropertyName(string actual, string expected)
        {
            var result = ExpectedPropertyName(actual);
            Assert.Equal(expected, result);
        }

        private string ExpectedPropertyName(string xmlElementName)
        {
            var words = xmlElementName.Split("_");
            var wordsWithFirstLetterUpercase = words.Select(x => char.ToUpper(x[0]) + x.Substring(1).ToLower());
            var propertyName = string.Join(string.Empty, wordsWithFirstLetterUpercase);
            return propertyName;
        }
    }
}