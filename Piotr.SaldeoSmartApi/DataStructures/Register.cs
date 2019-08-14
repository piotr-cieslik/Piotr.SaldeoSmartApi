using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Register
    {
        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("REGISTER_PROGRAM_ID")]
        public string RegisterProgramId { get; set; }

        [XmlElement("REGISTER_ID")]
        public int RegisterId { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("STATUS_MESSAGE")]
        public string StatusMessage { get; set; }

        // TODO PROGRAM_PARAMETERS
    }
}
