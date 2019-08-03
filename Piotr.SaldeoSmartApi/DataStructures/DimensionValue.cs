using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class DimensionValue
    {
        [XmlElement("CODE")]
        public string Code { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("ADDITIONAL_CODE")]
        public string AdditionalCode { get; set; }

        [XmlElement("IS_ACTIVE")]
        public string IsActive { get; set; }

        [XmlElement("VALUE")]
        public string Value { get; set; }
    }
}
