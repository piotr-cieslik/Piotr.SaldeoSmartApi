using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Article
    {
        [XmlElement("ARTICLE_ID")]
        public string ArticleId { get; set; }

        [XmlElement("ARTICLE_PROGRAM_ID")]
        public string ArticleProgramId { get; set; }

        [XmlElement("CODE")]
        public string Code { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("UNIT")]
        public string Unit { get; set; }

        [XmlElement("PKWIU")]
        public string Pkwiu { get; set; }

        [XmlElement("FOR_INVOICES")]
        public bool? ForInvoices { get; set; }

        [XmlElement("FOR_DOCUMENTS")]
        public bool? ForDocuments { get; set; }

        [XmlArray("FOREIGN_CODES")]
        [XmlArrayItem("FOREIGN_CODE")]
        public ForeignCode[] ForeignCodes { get; set; }
    }
}
