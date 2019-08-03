using System.IO;
using System.IO.Compression;
using System.Text;

namespace Piotr.SaldeoSmartApi.Serialization
{
    /// <summary>
    /// Wrapper that takes string as input parameter (by constructor),
    /// performs gZip compression and return compressed string as array of bytes. 
    /// </summary>
    public sealed class GZippedString
    {
        private readonly string _value;

        public GZippedString(string value) => _value = value;

        public static implicit operator byte[](GZippedString x) => x.Bytes();

        public byte[] Bytes()
        {
            using (var sourceStream = new MemoryStream(Encoding.UTF8.GetBytes(_value)))
            {
                using (var targetStream = new MemoryStream())
                {
                    using (var gZipStream = new GZipStream(targetStream, CompressionLevel.Optimal))
                    {
                        sourceStream.CopyTo(gZipStream);
                    }
                    return targetStream.ToArray();
                }
            }
        }
    }
}
