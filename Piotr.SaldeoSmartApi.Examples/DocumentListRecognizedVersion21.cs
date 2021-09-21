using System;
using System.Linq;
using System.Threading.Tasks;
using Piotr.SaldeoSmartApi.DataStructures;
using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi.Examples
{
    internal sealed class DocumentListRecognizedVersion21
    {
        public async Task Run()
        {
            // Specify your username.
            var username = Environment.GetEnvironmentVariable("SaldeoSmartUsername");

            // Specify your token.
            var token = Environment.GetEnvironmentVariable("SaldeoSmartToken");

            // Specify your company program id.
            var companyProgramId = Environment.GetEnvironmentVariable("SaldeoSmartCompanyProgramId");

            // Specify the server address.
            var server = new Uri("https://saldeo.brainshare.pl");

            // Create an instance of the API.
            var api = new Api(server);

            // Select path (operation).
            var path = Paths.DocumentListRecognized.Version21;

            // Specify document ids.
            var request =
                new Request
                {
                    OcrIdList = new string[]
                    {
                        "1",
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
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    result.Companies.Select(x => x.FullName)));
        }
    }
}
