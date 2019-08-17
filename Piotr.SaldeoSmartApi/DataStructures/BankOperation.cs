using System;
using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class BankOperation
    {
        [XmlElement("SALDEOSMART_MATCHING")]
        public SaldeosmartMatching SaldeosmartMatching { get; set; }

        [XmlElement("BANK_OPERATION_ACCOUNT_NUMBER")]
        public string BankOperationAccountNumber { get; set; }

        [XmlElement("BANK_OPERATION_TYPE")]
        public string BankOperationType { get; set; }

        [XmlElement("OPERATION_DATE")]
        public DateTime? OperationDate { get; set; }

        [XmlElement("ACCOUNTING_DATE")]
        public DateTime? AccountingDate { get; set; }

        [XmlElement("OPERATION_DESCRIPTION")]
        public string OperationDescription { get; set; }

        [XmlElement("VALUE")]
        public decimal? Value { get; set; }

        [XmlElement("DEBIT_CREDIT")]
        public string DebitCredit { get; set; }

        [XmlElement("CURRENCY_ISO4217")]
        public string CurrencyISO4217 { get; set; }

        [XmlElement("CURRENCY_RATE")]
        public decimal? CurrencyRate { get; set; }

        [XmlElement("CURRENCY_FACTOR")]
        public decimal? CurrencyFactor { get; set; }

        [XmlElement("CURRENCY_TABLE")]
        public string CurrencyTable { get; set; }

        [XmlElement("CURRENCY_DATE")]
        public DateTime? CurrencyDate { get; set; }

        [XmlElement("IS_APPROVED")]
        public bool? IsApproved { get; set; }

        [XmlElement("IS_REFUND")]
        public bool? IsRefund { get; set; }

        // TODO PROGRAM_PARAMETERS
    }
}
