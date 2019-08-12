using System.IO;
using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi.Tests
{
    internal sealed class XmlFile
    {
        private readonly string _fileName;

        public XmlFile(string fileName)
        {
            _fileName = fileName;
        }

        public DataStructures.Response Deserialize()
        {
            var assemblyLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(assemblyLocation, _fileName);
            return File.ReadAllText(path).Deserialize();
        }
    }
}
