using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class VatRegistry
    {
        [XmlElement("RATE")]
        public string Rate { get; set; }

        [XmlElement("NETTO")]
        public decimal Netto { get; set; }

        [XmlElement("VAT")]
        public decimal Vat { get; set; }
    }
}
