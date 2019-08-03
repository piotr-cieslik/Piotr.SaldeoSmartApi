using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Folder
    {
        [XmlElement("MONTH")]
        public int Month { get; set; }

        [XmlElement("YEAR")]
        public int Year { get; set; }
    }
}