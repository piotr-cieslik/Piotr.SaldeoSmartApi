# SaldeoSmartApi
Unofficial .net wrapper for SaldeoSMART API (https://www.saldeosmart.pl). The library is not finished yet, but it's useful enough to share. It allows to send valid GET and POST request to the API. Please notice that I am not working for company that owns SaldeoSMART and this wrapper is not approved by them.

The library was created based on documentation 3.0.22, from 25.03.2019.

Before you start using it, please make sure you have valid username and token. All operations requires same chunks of information:
- operation path,
- key-value pair of parameters,
- token.

## Get list of documents
``` csharp
// Specify your username.
var username = Environment.GetEnvironmentVariable("SaldeoSmartUsername");

// Specify your token.
var token = Environment.GetEnvironmentVariable("SaldeoSmartToken");

// Specify the server address.
var server = new Uri("https://saldeo.brainshare.pl");

// Create an instance of the API.
var api = new Api(server);

// Get list of companies (company.list operation).
var path =
	Paths.CompanyList.Version0;
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
```

## Merge dimensions of document
``` csharp
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
```
