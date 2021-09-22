using System;
using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Document
    {
        [XmlElement("DOCUMENT_ID")]
        public int? DocumentId { get; set; }

        [XmlElement("NUMBER")]
        public string Number { get; set; }

        [XmlElement("ISSUE_DATE")]
        public DateTime? IssueDate { get; set; }

        [XmlElement("SALE_DATE")]
        public DateTime? SaleDate { get; set; }

        [XmlElement("PAYMENT_DATE")]
        public DateTime? PaymentDate { get; set; }

        [XmlElement("RECEIVE_DATE")]
        public DateTime? ReceiveDate { get; set; }

        [XmlElement("DOCUMENT_TYPE")]
        public DocumentType DocumentType { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("CLASSIFICATION")]
        public string Classification { get; set; }

        [XmlElement("IS_CORRECTIVE")]
        public string IsCorrective { get; set; }

        [XmlElement("CORR_INV_NUM")]
        public string CorrInvNum { get; set; }

        [XmlElement("CORR_INV_DATE")]
        public string CorrInvDate { get; set; }

        [XmlElement("IS_VAT_MARGIN")]
        public bool? IsVatMargin { get; set; }

        [XmlElement("IS_CASH_BASIS")]
        public bool? IsCashBasis { get; set; }

        [XmlElement("CONTRACTOR")]
        public Contractor Contractor { get; set; }

        [XmlArray("BANK_ACCOUNTS")]
        [XmlArrayItem("BANK_ACCOUNT")]
        public string[] BankAccounts { get; set; }

        [XmlElement("CATEGORY")]
        public string Category { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("REGISTRY")]
        public string Registry { get; set; }

        [XmlElement("FOLDER")]
        public Folder Folder { get; set; }

        [XmlElement("SUM")]
        public decimal? Sum { get; set; }

        [XmlArray("VAT_REGISTRIES")]
        [XmlArrayItem("VAT_REGISTRY")]
        public VatRegistry[] VatRegistries { get; set; }

        [XmlArray("ITEMS")]
        [XmlArrayItem("ITEM")]
        public Item[] Items { get; set; }

        [XmlElement("LANG_ISO639_1")]
        public string LangISO6391 { get; set; }

        [XmlElement("CURRENCY_ISO4217")]
        public string CurrencyISO4217 { get; set; }

        [XmlElement("CURRENCY_RATE")]
        public string CurrencyRate { get; set; }

        [XmlElement("CURRENCY_FACTOR")]
        public string CurrencyFactor { get; set; }

        [XmlElement("CURRENCY_TABLE")]
        public string CurrencyTable { get; set; }

        [XmlElement("CURRENCY_DATE")]
        public DateTime? CurrencyDate { get; set; }

        [XmlElement("PAYMENT_TYPE")]
        public string PaymentType { get; set; }

        [XmlArray("REGISTRATION_NUMBERS")]
        [XmlArrayItem("REGISTRATION_NUMBER")]
        public string[] RegistrationNumbers { get; set; }

        [XmlElement("STAGE")]
        public string Stage { get; set; }

        [XmlElement("VERIFIED")]
        public string Verified { get; set; }

        [XmlElement("APPROVED")]
        public bool? Approved { get; set; }

        [XmlElement("EXPORTED")]
        public string Exported { get; set; }

        [XmlElement("ARCHIVIZATION_DATE")]
        public DateTime? ArchivizationDate { get; set; }

        [XmlElement("PAGE_COUNT")]
        public int? PageCount { get; set; }

        [XmlArray("PREVIEWS")]
        [XmlArrayItem("PREVIEW_URL")]
        public string[] Previews { get; set; }

        [XmlElement("SOURCE")]
        public string Source { get; set; }

        [XmlArray("DIMENSIONS")]
        [XmlArrayItem("DIMENSION")]
        public Dimension[] Dimensions { get; set; }

        [XmlArray("SALDEO_SYNC_DOCUMENTS")]
        [XmlArrayItem("SALDEO_SYNC_DOCUMENT")]
        public SaldeoSyncDocument[] SaldeoSyncDocuments { get; set; }

        [XmlElement("SEND_BY_USER")]
        public string SendByUser { get; set; }

        [XmlElement("IS_DOCUMENT_PAID")]
        public bool? IsDocumentPaid { get; set; }

        [XmlElement("IS_DOCUMENT_BELONG_TO_COMPANY")]
        public bool? IsDocumentBelongToCompany { get; set; }

        [XmlArray("DOCUMENT_PAYMENTS")]
        [XmlArrayItem("DOCUMENT_PAYMENT")]
        public DocumentPayment[] DocumentPayments { get; set; }

        [XmlArray("ATTACHMENTS")]
        [XmlArrayItem("ATTACHMENT")]
        public Attachment[] Attachments { get; set; }

        [XmlArray("DOCUMENT_ITEMS")]
        [XmlArrayItem("DOCUMENT_ITEM")]
        public DocumentItem[] DocumentItems { get; set; }

        [XmlElement("ATTMNT")]
        public string Attmnt { get; set; }

        [XmlElement("ATTMNT_NAME")]
        public string AttmntName { get; set; }

        // No matter how crazy it is, the "VatNumber" field has to be defined before "SplitMode" to make request works.
        // In other case the method "document.add_recognize" returns error saying that VatNumber is required.
        [XmlElement("VAT_NUMBER")]
        public string VatNumber { get; set; }

        [XmlElement("SPLIT_MODE")]
        public string SplitMode { get; set; }

        [XmlElement("NO_ROTATE")]
        public string NoRotate { get; set; }

        [XmlElement("OVERWRITE_DATA")]
        public string OverwriteData { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }

        [XmlElement("OCR_ORIGIN_ID")]
        public string OcrOriginId { get; set; }

        [XmlElement("COST")]
        public string Cost { get; set; }

        [XmlElement("SENT_DOCUMENT_COUNT")]
        public string SentDocumentCount { get; set; }

        [XmlElement("SENT_PAGE_COUNT")]
        public string SentPageCount { get; set; }

        [XmlElement("UPDATE_STATUS")]
        public string UpdateStatus { get; set; }

        [XmlElement("ERROR_MESSAGE")]
        public string ErrorMessage { get; set; }

        // Do not serialize null values
        // https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/defining-default-values-with-the-shouldserialize-and-reset-methods?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
        public bool ShouldSerializeDocumentId() => DocumentId != null;

        public bool ShouldSerializeIssueDate() => IssueDate != null;

        public bool ShouldSerializeSaleDate() => SaleDate != null;

        public bool ShouldSerializePaymentDate() => PaymentDate != null;

        public bool ShouldSerializeReceiveDate() => ReceiveDate != null;

        public bool ShouldSerializeIsVatMargin() => IsVatMargin != null;

        public bool ShouldSerializeIsCashBasis() => IsCashBasis != null;

        public bool ShouldSerializeSum() => Sum != null;

        public bool ShouldSerializeCurrencyDate() => CurrencyDate != null;

        public bool ShouldSerializeApproved() => Approved != null;

        public bool ShouldSerializeArchivizationDate() => ArchivizationDate != null;

        public bool ShouldSerializePageCount() => PageCount != null;

        public bool ShouldSerializeIsDocumentPaid() => IsDocumentPaid != null;

        public bool ShouldSerializeIsDocumentBelongToCompany() => IsDocumentBelongToCompany != null;

        // TODO PROGRAM_PARAMETERS
    }
}
