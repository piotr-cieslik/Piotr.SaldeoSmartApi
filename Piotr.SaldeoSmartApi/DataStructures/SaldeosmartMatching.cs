using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class SaldeosmartMatching
    {
        [XmlElement("CONTRACTOR")]
        public Contractor Contractor { get; set; }
    }
}
