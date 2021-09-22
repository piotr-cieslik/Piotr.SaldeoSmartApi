using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    [XmlRoot("RESPONSE")]
    public sealed class Response
    {
        [XmlElement("METAINF")]
        public Metainf Metainf { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("ERROR_CODE")]
        public string ErrorCode { get; set; }

        [XmlElement("ERROR_MESSAGE")]
        public string ErrorMessage { get; set; }

        [XmlArray("ERRORS")]
        [XmlArrayItem("ERROR")]
        public Error[] Errors { get; set; }

        [XmlArray("COMPANIES")]
        [XmlArrayItem("COMPANY")]
        public Company[] Companies { get; set; }

        [XmlArray("CONTRACTORS")]
        [XmlArrayItem("CONTRACTOR")]
        public Contractor[] Contractors { get; set; }

        [XmlArray("DOCUMENTS")]
        [XmlArrayItem("DOCUMENT")]
        public Document[] Documents { get; set; }

        [XmlElement("DOCUMENT")]
        public Document Document { get; set; }

        [XmlArray("DOCUMENT_DELETES")]
        [XmlArrayItem("DOCUMENT_DELETE")]
        public DocumentDelete[] DocumentDeletes { get; set; }

        [XmlArray("RESULTS")]
        [XmlArrayItem(ElementName = "ARTICLE", Type = typeof(Article))]
        [XmlArrayItem(ElementName = "CATEGORY", Type = typeof(Category))]
        [XmlArrayItem(ElementName = "COMPANY", Type = typeof(Company))]
        [XmlArrayItem(ElementName = "CONTRACTOR", Type = typeof(Contractor))]
        [XmlArrayItem(ElementName = "DESCRIPTION", Type = typeof(Description))]
        [XmlArrayItem(ElementName = "DIMENSION", Type = typeof(Dimension))]
        [XmlArrayItem(ElementName = "DOCUMENT", Type = typeof(Document))]
        [XmlArrayItem(ElementName = "DOCUMENT_DIMENSION", Type = typeof(DocumentDimension))]
        [XmlArrayItem(ElementName = "DOCUMENTS_SYNCED", Type = typeof(DocumentsSynced))]
        [XmlArrayItem(ElementName = "PAYMENT_METHOD", Type = typeof(PaymentMethod))]
        [XmlArrayItem(ElementName = "REGISTER", Type = typeof(Register))]
        public object[] Results { get; set; }

        [XmlArray("ARTICLES")]
        [XmlArrayItem("ARTICLE")]
        public Article[] Articles { get; set; }

        [XmlElement("WALLET")]
        public Wallet Wallet { get; set; }

        [XmlArray("BANK_STATEMENTS")]
        [XmlArrayItem("BANK_STATEMENT")]
        public BankStatement[] BankStatements { get; set; }

        public IEnumerable<T> ResultsOfType<T>() => Results?.Where(x => x.GetType() == typeof(T)).Cast<T>() ?? Enumerable.Empty<T>();

        public IEnumerable<Article> ResultsOfTypeArticle() => ResultsOfType<Article>();

        public IEnumerable<Category> ResultsOfTypeCategory() => ResultsOfType<Category>();

        public IEnumerable<Company> ResultsOfTypeCompany() => ResultsOfType<Company>();

        public IEnumerable<Contractor> ResultsOfTypeContractor() => ResultsOfType<Contractor>();

        public IEnumerable<Description> ResultsOfTypeDescription() => ResultsOfType<Description>();

        public IEnumerable<Dimension> ResultsOfTypeDimension() => ResultsOfType<Dimension>();

        public IEnumerable<Document> ResultsOfTypeDocument() => ResultsOfType<Document>();

        public IEnumerable<DocumentDimension> ResultsOfTypeDocumentDimension() => ResultsOfType<DocumentDimension>();

        public IEnumerable<DocumentsSynced> ResultsOfTypeDocumentsSynced() => ResultsOfType<DocumentsSynced>();

        public IEnumerable<PaymentMethod> ResultsOfTypePaymentMethod() => ResultsOfType<PaymentMethod>();

        public IEnumerable<Register> ResultsOfTypeRegister() => ResultsOfType<Register>();
    }
}
