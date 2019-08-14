using System.Xml.Serialization;

namespace Piotr.SaldeoSmartApi.DataStructures
{
    public sealed class Category
    {
        [XmlElement("CATEGORY_PROGRAM_ID")]
        public string CategoryProgramId { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        // TODO PROGRAM_PARAMETERS
    }
}
