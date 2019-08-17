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

        [XmlElement("DESCRIPTION")]
        public Description Description { get; set; }

        [XmlElement("DIMENSION")]
        public Dimension Dimension { get; set; }

        [XmlElement("DOCUMENT")]
        public Document Document { get; set; }

        [XmlElement("DOCUMENT_DIMENSION")]
        public DocumentDimension DocumentDimension { get; set; }

        [XmlElement("DOCUMENTS_SYNCED")]
        public DocumentsSynced DocumentsSynced { get; set; }

        [XmlElement("PAYMENT_METHOD")]
        public PaymentMethod PaymentMethod { get; set; }

        [XmlElement("REGISTER")]
        public Register Register { get; set; }
    }
}
