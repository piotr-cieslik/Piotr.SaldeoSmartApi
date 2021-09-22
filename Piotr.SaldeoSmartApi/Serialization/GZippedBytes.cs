using System.IO;
using System.IO.Compression;

namespace Piotr.SaldeoSmartApi.Serialization
{
    /// <summary>
    /// Wrapper that takes array of bytes as input parameter (by constructor),
    /// performs gZip compression and return compressed string as array of bytes.
    /// </summary>
    public sealed class GZippedBytes
    {
        private readonly byte[] _value;

        public GZippedBytes(byte[] value) => _value = value;

        public static implicit operator byte[](GZippedBytes x) => x.Bytes();

        public byte[] Bytes()
        {
            using (var sourceStream = new MemoryStream(_value))
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
