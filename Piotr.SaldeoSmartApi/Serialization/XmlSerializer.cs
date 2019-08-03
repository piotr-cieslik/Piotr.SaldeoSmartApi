using System.IO;

namespace Piotr.SaldeoSmartApi.Serialization
{
    public sealed class XmlSerializer
    {
        public string Serialize(DataStructures.Root root)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(DataStructures.Root));
            using (var stringWriter = new Utf8StringWriter())
            {
                serializer.Serialize(stringWriter, root);
                var xml = stringWriter.ToString();
                return xml;
            }
        }

        public DataStructures.Response Deserialize(string xml)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(DataStructures.Response));
            using (var reader = new StringReader(xml))
            {
                var result = (DataStructures.Response)serializer.Deserialize(reader);
                return result;
            }
        }
    }
}