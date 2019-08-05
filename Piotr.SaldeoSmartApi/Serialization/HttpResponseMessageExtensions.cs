using System.Net.Http;
using System.Threading.Tasks;

namespace Piotr.SaldeoSmartApi.Serialization
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<DataStructures.Response> Deserialize(this Task<HttpResponseMessage> response)
        {
            var content = await (await response).Content.ReadAsStringAsync();
            return content.Deserialize();
        }
    }
}