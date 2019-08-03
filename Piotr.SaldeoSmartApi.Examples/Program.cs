using System;
using System.Linq;
using System.Threading.Tasks;
using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi.Examples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Specify your username.
            var username = Environment.GetEnvironmentVariable("SaldeoSmartUsername");

            // Specify your token.
            var token = Environment.GetEnvironmentVariable("SaldeoSmartToken");

            // Specify the server address.
            var server = new Uri("https://saldeo.brainshare.pl");

            // Create an instance of the API.
            var api = new Api(server);

            // Get list of companies (company.list operation).
            {
                var path = Paths.CompanyList.Version0;
                var parameters =
                    new Parameters()
                            .AddUsername(username)
                            .AddRequestIdBasedOnUtcTime();
                var request =
                    api.GetAsync(
                        path,
                        parameters,
                        new Token(token));
                var result = await request.Deserialize();
                Console.WriteLine(
                    string.Join(Environment.NewLine, result.Companies.Select(x => x.FullName)));
            }
        }
    }
}
