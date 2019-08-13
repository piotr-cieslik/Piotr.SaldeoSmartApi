using System.Text;

namespace Piotr.SaldeoSmartApi
{
    internal sealed class Md5OfString
    {
        private readonly string _value;

        public Md5OfString(string value) => _value = value;

        public static implicit operator string(Md5OfString x) => x.ToString();

        public override string ToString()
        {
            var hash = Hash();
            var builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }

        private byte[] Hash()
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(_value);
            var hash = md5.ComputeHash(inputBytes);
            return hash;
        }
    }
}
