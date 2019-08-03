using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Piotr.SaldeoSmartApi
{
    public sealed class Parameters
        : IEnumerable<KeyValuePair<string, string>>
    {
        private ImmutableDictionary<string, string> _dictionary;

        public Parameters()
        {
            _dictionary = new Dictionary<string, string>().ToImmutableDictionary();
        }

        public Parameters(ImmutableDictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }

        public Parameters Add(string key, string value)
        {
            return new Parameters(_dictionary.Add(key, value));
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}