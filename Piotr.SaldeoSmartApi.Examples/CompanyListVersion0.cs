using System;
using System.Linq;
using System.Threading.Tasks;
using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi.Examples
{
    internal sealed class CompanyListVersion0
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
            var path = Paths.CompanyList.Version0;

            var parameters =
                new Parameters()                            // Create paramters.
                    .AddUsername(username)                  // Specify username.
                    .AddRequestIdBasedOnUtcTime();          // Specify unique request ID.        
            var request =
                api.GetAsync(
                    path,
                    parameters,
                    new Token(token));
            var result =
                await request.Deserialize();
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    result.Companies.Select(x => x.FullName)));
        }
    }
}
