using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piotr.SaldeoSmartApi
{
    internal sealed class Signature
    {
        private readonly Token _token;
        private readonly IEnumerable<KeyValuePair<string, string>> _parameters;

        public Signature(
            Token token,
            IEnumerable<KeyValuePair<string, string>> parameters)
        {
            _token = token;
            _parameters = parameters;
        }

        public static implicit operator string(Signature x) => x.ToString();

        public override string ToString()
        {
            var mergedString = new StringBuilder();
            foreach (var parameter in _parameters.OrderBy(x => x.Key))
            {
                mergedString.Append(parameter.Key).Append("=").Append(parameter.Value);
            }

            var singatureBase = new UrlEncodedString(mergedString.ToString());
            var signature = new Md5OfString(singatureBase + _token);
            return signature;
        }
    }
}