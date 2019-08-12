using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Results
    {
        [XmlElement("COMPANY")]
        public Company Company { get; set; }

        [XmlElement("DOCUMENT")]
        public Document Document { get; set; }
    }
}
