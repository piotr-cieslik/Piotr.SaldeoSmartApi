using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Description
    {
        [XmlElement("PROGRAM_ID")]
        public string ProgramId { get; set; }

        [XmlElement("VALUE")]
        public string Value { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }
    }
}
