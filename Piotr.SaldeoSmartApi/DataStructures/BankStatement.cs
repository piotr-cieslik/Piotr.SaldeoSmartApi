using System;
using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class BankStatement
    {
        [XmlElement("FOLDER")]
        public Folder Folder { get; set; }

        [XmlElement("BANK_STATEMENT_ACCOUNT_NUMBER")]
        public string BankStatementAccountNumber { get; set; }

        [XmlElement("CURRENCY_ISO4217")]
        public string CurrencyISO4217 { get; set; }

        [XmlElement("BANK_STATEMENT_PERIOD_FROM")]
        public DateTime? BankStatementPeriodFrom { get; set; }

        [XmlElement("BANK_STATEMENT_PERIOD_TO")]
        public DateTime? BankStatementPeriodTo { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("STATUS_DATE")]
        public DateTime? StatusDate { get; set; }

        [XmlElement("BANK_STATEMENT_FILENAME")]
        public DateTime? BankStatementFilename { get; set; }

        [XmlElement("SOURCE")]
        public string Source { get; set; }

        [XmlArray("PREVIEWS")]
        [XmlArrayItem("PREVIEW_URL")]
        public string[] Previews { get; set; }

        [XmlArray("BANK_OPERATIONS")]
        [XmlArrayItem("BANK_OPERATION")]
        public BankOperation[] BankOperations { get; set; }

        // TODO PROGRAM_PARAMETERS
    }
}
