namespace Piotr.SaldeoSmartApi.Serialization
{
    public static class StringsExtensions
    {
        public static DataStructures.Response Deserialize(this string content)
        {
            return new XmlSerializer().Deserialize(content);
        }
    }
}