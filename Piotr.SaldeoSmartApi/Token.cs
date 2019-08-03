using System;

namespace Piotr.SaldeoSmartApi
{
    public sealed class Token
    {
        private readonly string _value;

        public Token(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid token value.");
            }

            _value = value;
        }

        public static implicit operator string(Token x) => x.ToString();

        public override string ToString() => _value;
    }
}
