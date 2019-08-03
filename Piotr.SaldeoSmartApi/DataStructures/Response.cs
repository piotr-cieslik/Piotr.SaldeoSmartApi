using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    [XmlRoot("RESPONSE")]
    public sealed class Response
    {
        [XmlElement("METAINF")]
        public Metainf Metainf { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("ERROR_CODE")]
        public string ErrorCode { get; set; }

        [XmlElement("ERROR_MESSAGE")]
        public string ErrorMessage { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }

        [XmlArray("COMPANIES")]
        [XmlArrayItem("COMPANY")]
        public Company[] Companies { get; set; }

        [XmlArray("CONTRACTORS")]
        [XmlArrayItem("CONTRACTOR")]
        public Contractor[] Contractors { get; set; }

        [XmlArray("DOCUMENTS")]
        [XmlArrayItem("DOCUMENT")]
        public Document[] Documents { get; set; }
    }
}
