using System;
using System.Threading.Tasks;
using Piotr.SaldeoSmartApi.DataStructures;
using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi.Examples
{
    internal sealed class DocumentListRecognizedVersion21
    {
        public async Task Run()
        {
            var username = Environment.GetEnvironmentVariable("SaldeoSmartUsername");
            var token = Environment.GetEnvironmentVariable("SaldeoSmartToken");
            var server = new Uri("https://saldeo.brainshare.pl");
            var api = new Api(server);
            var path = Paths.DocumentListRecognized.Version21;

            // Specify document ids.
            var request =
                new Request
                {
                    OcrIdList = new string[]
                    {
                        "PUT ID HERE",
                    }
                };

            var command = request.Serialize();
            var parameters =
                new Parameters()
                    .AddUsername(username)
                    .AddRequestIdBasedOnUtcTime()
                    .AddCommand(command);
            var httpRequest =
                api.PostAsync(
                    path,
                    parameters,
                    new Token(token));
            var result =
                await httpRequest.Deserialize();
        }
    }
}
