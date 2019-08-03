using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Error
    {
        [XmlElement("PATH")]
        public string Path { get; set; }

        [XmlElement("MESSAGE")]
        public string Message { get; set; }
    }
}
