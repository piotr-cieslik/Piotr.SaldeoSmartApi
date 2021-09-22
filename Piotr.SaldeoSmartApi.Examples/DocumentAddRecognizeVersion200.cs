using System;
using System.IO;
using System.Threading.Tasks;
using Piotr.SaldeoSmartApi.DataStructures;
using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi.Examples
{
    internal sealed class DocumentAddRecognizeVersion200
    {
        public async Task Run()
        {
            var username = Environment.GetEnvironmentVariable("SaldeoSmartUsername");
            var token = Environment.GetEnvironmentVariable("SaldeoSmartToken");
            var server = new Uri("https://saldeo.brainshare.pl");
            var api = new Api(server);
            var path = Paths.DocumentAddRecognize.Version200;

            var file = File.ReadAllBytes(@"PATH TO FILE");

            var request =
                new Request
                {
                    Document = new Document
                    {
                        VatNumber = "NIP HERE",
                        // Does not work without this parameter,
                        // even though specification says something different :). 
                        SplitMode = "SPLIT_ONE_SIDED",
                    }
                };
            var command =
                request.Serialize();
            var parameters =
                new Parameters()
                    .AddUsername(username)
                    .AddRequestIdBasedOnUtcTime()
                    .AddCommand(command)
                    .AddAttmnt("1", file);
            var response =
                api.PostAsync(
                    path,
                    parameters,
                    new Token(token));
            var result =
                await response.Deserialize();
        }
    }
}
