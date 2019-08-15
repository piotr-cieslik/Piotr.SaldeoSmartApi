using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class SaldeoDocument
    {
        [XmlElement("SYNC_ID")]
        public string SyncId { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("DOCUMENT_ID")]
        public string DocumentId { get; set; }
    }
}
