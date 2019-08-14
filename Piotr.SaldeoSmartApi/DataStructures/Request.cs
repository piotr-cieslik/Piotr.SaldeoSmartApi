using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    [XmlRoot("ROOT")]
    public sealed class Request
    {
        [XmlArray("COMPANIES")]
        [XmlArrayItem("COMPANY")]
        public Company[] Companies { get; set; }

        [XmlArray("DOCUMENT_DIMENSIONS")]
        [XmlArrayItem("DOCUMENT_DIMENSION")]
        public DocumentDimension[] DocumentDimensions { get; set; }

        [XmlElement("SEARCH_POLICY")]
        public string SearchPolicy { get; set; }

        [XmlElement("FIELDS")]
        public Fields Fields { get; set; }
    }
}
