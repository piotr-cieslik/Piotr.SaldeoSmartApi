using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class DocumentDelete
    {
        [XmlElement("DOCUMENT_ID")]
        public int DocumentId { get; set; }

        [XmlElement("DOCUMENT_DELETE_STATUS")]
        public string DocumentDeleteStatus { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }
    }
}
