using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class DocumentItem
    {
        [XmlElement("ARTICLE_ID")]
        public string ArticleId { get; set; }

        [XmlElement("CODE")]
        public string Code { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("AMOUNT")]
        public string Amount { get; set; }

        [XmlElement("UNIT")]
        public string Unit { get; set; }

        [XmlElement("RATE")]
        public string Rate { get; set; }

        [XmlElement("UNIT_VALUE")]
        public string UnitValue { get; set; }

        [XmlElement("NETTO")]
        public decimal? Netto { get; set; }

        [XmlElement("VAT")]
        public decimal? Vat { get; set; }

        [XmlElement("GROSS")]
        public decimal? Gross { get; set; }
    }
}
