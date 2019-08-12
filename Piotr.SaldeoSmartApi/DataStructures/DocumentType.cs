using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class DocumentType
    {
        [XmlElement("ID")]
        public string Id { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("SHORT_NAME")]
        public string ShortName { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }
    }
}
