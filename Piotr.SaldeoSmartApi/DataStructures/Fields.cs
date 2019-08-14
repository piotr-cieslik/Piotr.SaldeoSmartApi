using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    /// <summary>
    /// Please notice that the plural name "Fields" (not "Field")
    /// is used in documentation of document.search v1.18 operation.
    /// </summary>
    public sealed class Fields
    {
        [XmlElement("DOCUMENT_ID")]
        public int DocumentId { get; set; }

        [XmlElement("NUMBER")]
        public string Number { get; set; }

        [XmlElement("NIP")]
        public string Nip { get; set; }

        [XmlElement("GUID")]
        public string Guid { get; set; }
    }
}
