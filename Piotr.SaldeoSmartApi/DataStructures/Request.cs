using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    [XmlRoot("ROOT")]
    public sealed class Request
    {
        [XmlArray("CATEGORIES")]
        [XmlArrayItem("CATEGORY")]
        public Category[] Categories { get; set; }

        [XmlArray("COMPANIES")]
        [XmlArrayItem("COMPANY")]
        public Company[] Companies { get; set; }

        [XmlArray("CONTRACTORS")]
        [XmlArrayItem("CONTRACTOR")]
        public Contractor[] Contractor { get; set; } // TODO Rename to Contractors.

        [XmlArray("DIMENSIONS")]
        [XmlArrayItem("DIMENSION")]
        public Dimension[] Dimensions { get; set; }

        [XmlArray("DOCUMENT_DIMENSIONS")]
        [XmlArrayItem("DOCUMENT_DIMENSION")]
        public DocumentDimension[] DocumentDimensions { get; set; }

        [XmlArray("PAYMENT_METHODS")]
        [XmlArrayItem("PAYMENT_METHOD")]
        public PaymentMethod[] PaymentMethods { get; set; }

        [XmlArray("REGISTERS")]
        [XmlArrayItem("REGISTER")]
        public Register[] Registers { get; set; }

        [XmlElement("SEARCH_POLICY")]
        public string SearchPolicy { get; set; }

        [XmlElement("FIELDS")]
        public Fields Fields { get; set; }
    }
}
