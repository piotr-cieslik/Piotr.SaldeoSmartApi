using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class BankAccount
    {
        [XmlElement("NUMBER")]
        public string Number { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }
    }
}
