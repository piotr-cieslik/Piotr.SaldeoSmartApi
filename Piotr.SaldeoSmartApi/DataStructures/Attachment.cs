using System;
using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Attachment
    {
        [XmlElement("ATTACHMENT_ID")]
        public string AttachementId { get; set; }

        [XmlElement("CREATE_DATE")]
        public DateTime? CreateDate { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("FILENAME")]
        public string Filename { get; set; }

        [XmlElement("SOURCE")]
        public string Source { get; set; }
    }
}
