using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class ForeignCode
    {
        [XmlElement("CONTRACTOR_ID")]
        public string ContractorId { get; set; }

        [XmlElement("CODE")]
        public string Code { get; set; }
    }
}
