# SaldeoSmartApi

[![Build Status](https://dev.azure.com/piotrcieslik/public/_apis/build/status/piotr-cieslik.Piotr.SaldeoSmartApi?branchName=master)](https://dev.azure.com/piotrcieslik/public/_build/latest?definitionId=2&branchName=master)

Unofficial .net wrapper for SaldeoSMART API (https://www.saldeosmart.pl). The library is not finished yet, but it's useful enough to share. It allows to send valid GET and POST request to the API. Please notice that I am not working for company that owns SaldeoSMART and this wrapper is not approved by them.

The library was created based on documentation 3.0.22, from 25.03.2019.

Before using it, please make sure you have valid username and token. All operations requires same chunks of information:
- operation path,
- key-value pair of parameters,
- token.

## Example: get list of documents
``` csharp
// Specify your username.
var username = Environment.GetEnvironmentVariable("SaldeoSmartUsername");

// Specify your token.
var token = Environment.GetEnvironmentVariable("SaldeoSmartToken");

// Specify the server address.
var server = new Uri("https://saldeo.brainshare.pl");

// Create an instance of the API.
var api = new Api(server);

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

## Example: merge dimensions of document
``` csharp
// Specify your username.
var username = Environment.GetEnvironmentVariable("SaldeoSmartUsername");

// Specify your token.
var token = Environment.GetEnvironmentVariable("SaldeoSmartToken");

// Specify the server address.
var server = new Uri("https://saldeo.brainshare.pl");

// Create an instance of the API.
var api = new Api(server);

var path =
    Paths.DocumentDimensionMerge.Version0;
var request =
    new Request
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

## Parameters
The class `Parameters` represent key-value pair, immutable dictionary that holds information specified by operation. It's very simple type that contains single method `Add(string key, string value)`. To make it easier to use, there is plenty of predefined extension method like `AddUsername(string value)` or `AddRequestId(string value)`. Feel free to define you own extension methods for missing parameters.

You can define parameter name explicity:
``` csharp
var parameters = new Parameters().Add("username", "piotr");
```

or use one of the extension methods:
``` csharp
var parameters = new Parameters().AddUsername("piotr");
```

The only parameter you **shouldn't define** is `req_sig`. It's calculated and added to request automatically when sending. 
