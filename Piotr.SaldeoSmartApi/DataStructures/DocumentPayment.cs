using System;
using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class DocumentPayment
    {
        [XmlElement("PAYMENT_DATE")]
        public DateTime? PaymentDate { get; set; }

        [XmlElement("PAYMENT_AMOUNT")]
        public decimal PaymentAmount { get; set; }
    }
}
