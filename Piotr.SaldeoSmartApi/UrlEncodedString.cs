using System.Collections.Generic;

namespace Piotr.SaldeoSmartApi
{
    /// <summary>
    /// Wrapper over HttpUtility.UrlEncode method, that ensures same encoding standard as used by SaldeSMART.
    /// </summary>
    internal sealed class UrlEncodedString
    {
        private readonly string _value;

        public UrlEncodedString(string value) => _value = value;

        public static implicit operator string(UrlEncodedString x) => x.ToString();

        public override string ToString() => string.Join("", EncodeCharacters());

        private IEnumerable<string> EncodeCharacters()
        {
            foreach (var character in _value)
            {
                var encoded = System.Net.WebUtility.UrlEncode(character.ToString());

                if (encoded == "!")
                {
                    yield return "%21";
                    continue;
                }

                if (encoded == "(")
                {
                    yield return "%28";
                    continue;
                }

                if (encoded == ")")
                {
                    yield return "%29";
                    continue;
                }

                // Ensure that hex representation is upper case
                if (encoded.StartsWith("%"))
                {
                    yield return encoded.ToUpper();
                    continue;
                }

                yield return encoded;
            }
        }
    }
}
