using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Dimension
    {
        [XmlElement("ADDITIONAL_CODE")]
        public string AdditionalCode { get; set; }

        [XmlElement("CODE")]
        public string Code { get; set; }

        [XmlArray("DIMENSION_VALUES")]
        [XmlArrayItem("DIMENSION_VALUE")]
        public DimensionValue[] DimensionValues { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("VALUE")]
        public string Value { get; set; }
    }
}
