using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class DocumentDimension
    {
        [XmlElement("DOCUMENT_ID")]
        public int DocumentId { get; set; }

        [XmlElement("DIMENSION_CODE")]
        public string DimensionCode { get; set; }

        [XmlElement("DIMENSION_VALUE")]
        public string DimensionValue { get; set; }

        [XmlArray("DIMENSIONS")]
        [XmlArrayItem("DIMENSION")]
        public Dimension[] Dimensions { get; set; }

        [XmlElement("DOCUMENT_DIMENSION_STATUS")]
        public string DocumentDimensionStatus { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }
    }
}
