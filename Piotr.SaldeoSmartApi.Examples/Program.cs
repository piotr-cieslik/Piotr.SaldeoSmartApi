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

            // Specify your company program id.
            var companyProgramId = Environment.GetEnvironmentVariable("SaldeoSmartCompanyProgramId");

            // Specify the server address.
            var server = new Uri("https://saldeo.brainshare.pl");

            // Create an instance of the API.
            var api = new Api(server);

            // Get list of companies (company.list operation).
            {
                var path = Paths.CompanyList.Version0;
                var parameters =
                    new Parameters()
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

            // Get list of documents (document.list operation)
            {
                var path =
                    Paths.DocumentList.Version21;
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

            // Add dimension value to document
            {
                var path =
                    Paths.DocumentDimensionMerge.Version0;
                var request =
                    new Request
                    {
                        DocumentDimensions = new[]
                        {
                            new DocumentDimension
                            {
                                DocumentId = 40799538,          // Specify ID of document
                                Dimensions = new[]
                                {
                                    new Dimension
                                    {
                                        Code = "Liters",        // Specify dimension name
                                        Value = "100",          // Specify value
                                    }
                                }
                            },
                        }
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

            // Search documents (document.search operation)
            {
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
}
