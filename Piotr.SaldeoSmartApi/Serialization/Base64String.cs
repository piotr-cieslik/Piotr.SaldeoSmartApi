namespace Piotr.SaldeoSmartApi.Serialization
{
    public sealed class Base64String
    {
        private readonly byte[] _value;

        public Base64String(byte[] value) => _value = value;

        public static implicit operator string(Base64String x) => x.ToString();

        public override string ToString() => System.Convert.ToBase64String(_value);
    }
}