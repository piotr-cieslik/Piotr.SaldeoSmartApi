using System;
using System.Threading.Tasks;
using Piotr.SaldeoSmartApi.DataStructures;
using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi.Examples
{
    internal sealed class DocumentSearchVersion21
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
            var path =
                Paths.DocumentSearch.Version21;
            var request =
                new Request
                {
                    SearchPolicy = "BY_FIELDS",
                    Fields = new Fields
                    {
                        DocumentId = 123,
                    },
                };
            var parameters =
                new Parameters()
                    .AddUsername(username)                  // Specify username.
                    .AddCompanyProgramId(companyProgramId)  // Specify company name.
                    .AddRequestIdBasedOnUtcTime()           // Generate unique request ID.
                    .AddCommand(request.Serialize());       // Serialize request as valid XML
            var response =
                api.PostAsync(
                    path,
                    parameters,
                    new Token(token));
            var result =
                await response.Deserialize();               // Deserialize response into Response type.
        }
    }

}
