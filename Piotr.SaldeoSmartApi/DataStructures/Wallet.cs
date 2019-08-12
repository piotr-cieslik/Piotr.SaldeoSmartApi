using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Wallet
    {
        [XmlElement("REMAINING_CREDITS")]
        public int? RemainingCredits { get; set; }
    }
}
