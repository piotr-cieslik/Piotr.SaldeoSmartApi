namespace Piotr.SaldeoSmartApi.Serialization
{
    public static class RootExtensions
    {
        /// <summary>
        /// Helper method that performs serialization, compression and conversion to base64.
        /// </summary>
        /// <param name="root">Root element of the request.</param>
        /// <returns>Base64 string ready to send as command parameter.</returns>
        public static Base64String Serialize(this DataStructures.Request root)
        {
            var serializer = new XmlSerializer();
            var xml = serializer.Serialize(root);
            var gZiped = new GZippedString(xml);
            var base64 = new Base64String(gZiped);
            return base64;
        }
    }
}