using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Item
    {
        [XmlElement("EXTRACTION")]
        public bool? Extraction { get; set; }

        [XmlElement("RATE")]
        public string Rate { get; set; }

        [XmlElement("NETTO")]
        public decimal? Netto { get; set; }

        [XmlElement("VAT")]
        public decimal? Vat { get; set; }

        [XmlElement("CATEGORY")]
        public string Category { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlArray("DIMENSIONS")]
        [XmlArrayItem("DIMENSION")]
        public Dimension[] Dimensions { get; set; }

        // TODO Figure out what is it.
        // [XmlArray("PROGRAM_PARAMETERS")]
        // public object[] ProgramParameters { get; set; }
    }
}
