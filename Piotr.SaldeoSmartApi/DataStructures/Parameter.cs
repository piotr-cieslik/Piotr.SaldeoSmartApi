using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Parameter
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("VALUE")]
        public string Value { get; set; }
    }
}
