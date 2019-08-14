using System;
using System.Threading.Tasks;
using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi.Examples
{
    internal sealed class DocumentListVersion21
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
            var path = Paths.DocumentList.Version21;
            var parameters =
                new Parameters()
                    .AddUsername(username)                  // Specify username.
                    .AddRequestIdBasedOnUtcTime()           // Generate request ID based on current time.
                    .AddCompanyProgramId(companyProgramId)  // Specify name of the company.
                    .AddPolicy("LAST_10_DAYS");             // Specify policy.
            var request =
                api.GetAsync(
                    path,
                    parameters,
                    new Token(token));
            var result =
                await request.Deserialize();
        }
    }

}
