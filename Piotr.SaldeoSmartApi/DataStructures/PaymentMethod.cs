using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class PaymentMethod
    {
        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("PAYMENT_METHOD_ID")]
        public string PaymentMethodId { get; set; }

        [XmlElement("PAYMENT_METHOD_PROGRAM_ID")]
        public string PaymentMethodProgramId { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("STATUS_MESSAGE")]
        public string StatusMessage { get; set; }

        // TODO PROGRAM_PARAMETERS
    }
}