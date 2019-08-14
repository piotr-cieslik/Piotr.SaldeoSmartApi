using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Results
    {
        [XmlElement("CATEGORY")]
        public Category Category { get; set; }

        [XmlElement("COMPANY")]
        public Company Company { get; set; }

        [XmlElement("CONTRACTOR")]
        public Contractor Contractor { get; set; }

        [XmlElement("DOCUMENT")]
        public Document Document { get; set; }
    }
}
