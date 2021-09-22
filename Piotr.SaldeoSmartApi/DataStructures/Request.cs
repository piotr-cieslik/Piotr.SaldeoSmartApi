using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    [XmlRoot("ROOT")]
    public sealed class Request
    {
        [XmlArray("ARTICLES")]
        [XmlArrayItem("ARTICLE")]
        public Article[] Articles { get; set; }

        [XmlArray("CATEGORIES")]
        [XmlArrayItem("CATEGORY")]
        public Category[] Categories { get; set; }

        [XmlArray("COMPANIES")]
        [XmlArrayItem("COMPANY")]
        public Company[] Companies { get; set; }

        [XmlArray("CONTRACTORS")]
        [XmlArrayItem("CONTRACTOR")]
        public Contractor[] Contractors { get; set; }

        [XmlArray("DESCRIPTIONS")]
        [XmlArrayItem("DESCRIPTION")]
        public Description[] Descriptions { get; set; }

        [XmlArray("DIMENSIONS")]
        [XmlArrayItem("DIMENSION")]
        public Dimension[] Dimensions { get; set; }

        [XmlElement("DOCUMENT")]
        public Document Document { get; set; }

        [XmlArray("DOCUMENTS")]
        [XmlArrayItem("DOCUMENT")]
        public Document[] Documents { get; set; }

        [XmlArray("DOCUMENT_DELETE_IDS")]
        [XmlArrayItem("DOCUMENT_DELETE_ID")]
        public int[] DocumentDeleteIds { get; set; }

        [XmlArray("DOCUMENT_DIMENSIONS")]
        [XmlArrayItem("DOCUMENT_DIMENSION")]
        public DocumentDimension[] DocumentDimensions { get; set; }

        [XmlArray("DOCUMENT_SYNCS")]
        [XmlArrayItem("DOCUMENT_SYNC")]
        public DocumentSync[] DocumentSyncs { get; set; }

        [XmlArray("PAYMENT_METHODS")]
        [XmlArrayItem("PAYMENT_METHOD")]
        public PaymentMethod[] PaymentMethods { get; set; }

        [XmlArray("REGISTERS")]
        [XmlArrayItem("REGISTER")]
        public Register[] Registers { get; set; }

        [XmlElement("SEARCH_POLICY")]
        public string SearchPolicy { get; set; }

        [XmlElement("FIELDS")]
        public Fields Fields { get; set; }

        [XmlArray("OCR_ID_LIST")]
        [XmlArrayItem("OCR_ORIGIN_ID")]
        public string[] OcrIdList { get; set; }
    }
}
