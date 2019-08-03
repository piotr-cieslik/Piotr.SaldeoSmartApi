using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Metainf
    {
        [XmlElement("PRODUCER")]
        public string Producer { get; set; }

        [XmlElement("TIMESTAMP")]
        public string Timestamp { get; set; }

        [XmlElement("OPERATION")]
        public string Operation { get; set; }

        [XmlElement("VERSION")]
        public string Version { get; set; }

        [XmlArray("PARAMETERS")]
        [XmlArrayItem("PARAMETER")]
        public Parameter[] Parameters { get; set; }
    }
}
