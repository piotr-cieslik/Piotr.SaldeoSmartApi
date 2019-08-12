using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class SaldeoSyncDocument
    {
        [XmlElement("ID")]
        public string Id { get; set; }

        [XmlElement("GUID")]
        public string Guid { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("NUMBERING_TYPE")]
        public string NumberingType { get; set; }

        [XmlElement("ACCOUNT_DOCUMENT_NUMBER")]
        public string AccountDocumentNumber { get; set; }

        [XmlElement("DOCUMENT_STATUS")]
        public string DocumentStatus { get; set; }
    }
}
