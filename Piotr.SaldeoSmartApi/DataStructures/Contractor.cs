using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Contractor
    {
        [XmlElement("CONTRACTOR_PROGRAM_ID")]
        public string ContractorProgramId { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("STATUS_MESSAGE")]
        public string StatusMessage { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }

        [XmlElement("CONTRACTOR_ID")]
        public string ContractorId { get; set; }

        [XmlElement("SHORT_NAME")]
        public string ShortName { get; set; }

        [XmlElement("FULL_NAME")]
        public string FullName { get; set; }

        [XmlElement("SUPPLIER")]
        public bool? Supplier { get; set; }

        [XmlElement("CUSTOMER")]
        public bool? Customer { get; set; }

        [XmlElement("VAT_NUMBER")]
        public string VatNumber { get; set; }

        [XmlElement("CITY")]
        public string City { get; set; }

        [XmlElement("POSTCODE")]
        public string Postcode { get; set; }

        [XmlElement("STREET")]
        public string Street { get; set; }

        [XmlElement("COUNTRY_ISO3166A2")]
        public string CountryISO3166A2 { get; set; }

        [XmlArray("EMAILS")]
        [XmlArrayItem("EMAIL")]
        public string[] Emails { get; set; }

        [XmlElement("TELEPHONE")]
        public string Telephone { get; set; }

        [XmlElement("CONTACT_PERSON")]
        public string ContactPerson { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("PAYMENT_DAYS")]
        public int? PaymentDays { get; set; }

        [XmlArray("BANK_ACCOUNTS")]
        [XmlArrayItem("BANK_ACCOUNT")]
        public BankAccount[] BankAccounts { get; set; }

        [XmlElement("NIP")]
        public string Nip { get; set; }

        // TODO Figure out what is it.
        // [XmlArray("PROGRAM_PARAMETERS")]
        // public object[] ProgramParameters { get; set; }
    }
}
