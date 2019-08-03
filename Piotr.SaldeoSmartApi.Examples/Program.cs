using System;
using System.Linq;
using System.Threading.Tasks;
using Piotr.SaldeoSmartApi.DataStructures;
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
                        .AddUsername(username)  // Specify username.
                        .AddRequestId("1");     // Specify unique request ID.        
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

            // Get list of documents (document.list operation)
            {
                var path =
                    Paths.DocumentList.Version21;
                var parameters =
                    new Parameters()
                        .AddUsername(username)                  // Specify username.
                        .AddRequestIdBasedOnUtcTime()           // Generate request ID based on current time.
                        .AddCompanyProgramId("your company")    // Specify name of the company.
                        .AddPolicy("LAST_10_DAYS");             // Specify policy.
                var request =
                    api.GetAsync(
                        path,
                        parameters,
                        new Token(token));
                var result =
                    await request.Deserialize();
            }

            // Add dimension value to document
            {
                var path =
                    Paths.DocumentDimensionMerge.Version0;
                var request =
                    new Root
                    {
                        DocumentDimensions = new[]
                        {
                            new DocumentDimension
                            {
                                DocumentId = 40799538,      // Specify ID of document
                                Dimensions = new[]
                                {
                                    new Dimension
                                    {
                                        Code = "Liters",    // Specify dimension name
                                        Value = "100",      // Specify value
                                    }
                                }
                            },
                        }
                    };
                var parameters =
                    new Parameters()
                        .AddUsername(username)              // Specify username.
                        .AddCompanyProgramId("company")     // Specify company name.
                        .AddRequestIdBasedOnUtcTime()       // Generate unique request ID.
                        .AddCommand(request.Serialize());   // Serialize request as valid XML
                var response =
                    api.PostAsync(
                        path,
                        parameters,
                        new Token(token));
                var result =
                    await response.Deserialize();           // Deserialize response into Response type.
            }
        }
    }
}
