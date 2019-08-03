﻿using System;
using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Document
    {
        [XmlElement("DOCUMENT_ID")]
        public int DocumentId { get; set; }

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

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("CLASSIFICATION")]
        public string Classification { get; set; }

        [XmlElement("IS_CORRECTIVE")]
        public string IsCorrective { get; set; }

        [XmlElement("CORR_INV_NUM")]
        public string CorrectiveInvoiceNumber { get; set; }

        [XmlElement("CORR_INV_DATE")]
        public string CorrectiveInvoiceDate { get; set; }

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
        public string Language { get; set; }

        [XmlElement("CURRENCY_ISO4217")]
        public string Currency { get; set; }

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
        public int PageCount { get; set; }

        [XmlArray("PREVIEWS")]
        [XmlArrayItem("PREVIEW_URL")]
        public string[] Previews { get; set; }

        [XmlElement("SOURCE")]
        public string Source { get; set; }

        [XmlArray("DIMENSIONS")]
        [XmlArrayItem("DIMENSION")]
        public Dimension[] Dimensions { get; set; }

        //TODO Figure out what is it.
        //[XmlArray("PROGRAM_PARAMETERS")]
        //public object[] ProgramParameters { get; set; }
    }
}