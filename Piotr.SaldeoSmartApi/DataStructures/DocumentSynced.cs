using System;
using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class DocumentSynced
    {
        [XmlElement("CONTRACTOR_PROGRAM_ID")]
        public string ContractorProgramId { get; set; }

        [XmlElement("DOCUMENT_NUMBER")]
        public string DocumentNumber { get; set; }

        [XmlElement("GUID")]
        public string Guid { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("NUMBERING_TYPE")]
        public string NumberingType { get; set; }

        [XmlElement("ACCOUNT_DOCUMENT_NUMBER")]
        public string AccountDocumentNumber { get; set; }

        [XmlElement("SYNCED_STATUS")]
        public string SyncedStatus { get; set; }

        [XmlElement("ISSUE_DATE")]
        public DateTime? IssueDate { get; set; }

        [XmlElement("SALDEO_GUID")]
        public string SaldeoGuid { get; set; }

        [XmlArray("SALDEO_DOCUMENTS")]
        [XmlArrayItem("SALDEO_DOCUMENTS")]
        public SaldeoDocument[] SaldeoDocuments { get; set; }
    }
}
