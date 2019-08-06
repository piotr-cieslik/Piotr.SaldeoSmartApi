using System.Collections.Generic;
using System.Linq;

namespace Piotr.SaldeoSmartApi
{
    internal sealed class QueryString
    {
        private readonly IEnumerable<KeyValuePair<string, string>> _paramters;

        public QueryString(IEnumerable<KeyValuePair<string, string>> paramters) => _paramters = paramters;

        public static implicit operator string(QueryString x) => x.ToString();

        public override string ToString()
        {
            var parameters =
                _paramters
                    .Select(x => $"{System.Net.WebUtility.UrlEncode(x.Key)}={System.Net.WebUtility.UrlEncode(x.Value)}");
            var mergedParameters =
                string.Join("&", parameters);
            if (mergedParameters == string.Empty)
            {
                return string.Empty;
            }

            return "?" + mergedParameters;
        }
    }
}
