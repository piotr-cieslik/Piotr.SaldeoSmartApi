using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Dimension
    {
        [XmlElement("CODE")]
        public string Code { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("ADDITIONAL_CODE")]
        public string AdditionalCode { get; set; }

        [XmlElement("VALUE")]
        public string Value { get; set; }

        [XmlArray("DIMENSION_VALUES")]
        [XmlArrayItem("DIMENSION_VALUE")]
        public DimensionValue[] DimensionValues { get; set; }
    }
}
