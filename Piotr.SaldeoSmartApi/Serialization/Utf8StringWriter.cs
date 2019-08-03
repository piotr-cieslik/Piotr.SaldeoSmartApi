using System.IO;
using System.Text;

namespace Piotr.SaldeoSmartApi.Serialization
{
    internal sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
