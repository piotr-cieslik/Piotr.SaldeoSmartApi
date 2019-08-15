using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Company
    {
        [XmlElement("COMPANY_ID")]
        public string CompanyId { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("STATUS_MESSAGE")]
        public string StatusMessage { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }

        [XmlElement("COMPANY_PROGRAM_ID")]
        public string CompanyProgramId { get; set; }

        [XmlElement("FIRST_NAME")]
        public string FirstName { get; set; }

        [XmlElement("LAST_NAME")]
        public string LastName { get; set; }

        [XmlElement("EMAIL")]
        public string Email { get; set; }

        [XmlElement("USERNAME")]
        public string Username { get; set; }

        [XmlElement("PASSWORD")]
        public string Password { get; set; }

        [XmlElement("SHORT_NAME")]
        public string ShortName { get; set; }

        [XmlElement("FULL_NAME")]
        public string FullName { get; set; }

        [XmlElement("VAT_NUMBER")]
        public string VatNumber { get; set; }

        [XmlElement("CITY")]
        public string City { get; set; }

        [XmlElement("POSTCODE")]
        public string Postcode { get; set; }

        [XmlElement("STREET")]
        public string Street { get; set; }

        [XmlElement("TELEPHONE")]
        public string Telephone { get; set; }

        [XmlElement("CONTACT_PERSON")]
        public string ContactPerson { get; set; }

        [XmlArray("BANK_ACCOUNTS")]
        [XmlArrayItem("BANK_ACCOUNT")]
        public BankAccount[] BankAccounts { get; set; }

        [XmlElement("ZUS_BANK_ACCOUNT")]
        public string ZusBankAccount { get; set; }
    }
}
