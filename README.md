# SaldeoSmartApi

[![Build Status](https://dev.azure.com/piotrcieslik/public/_apis/build/status/piotr-cieslik.Piotr.SaldeoSmartApi?branchName=master)](https://dev.azure.com/piotrcieslik/public/_build/latest?definitionId=2&branchName=master)
![GitHub](https://img.shields.io/github/license/piotr-cieslik/Piotr.SaldeoSmartApi)
![Nuget](https://img.shields.io/nuget/dt/Piotr.SaldeoSmartApi)

Unofficial .net wrapper for SaldeoSMART API (https://www.saldeosmart.pl). The library is not finished yet, but it's useful enough to share. It allows to send valid GET and POST request to the API. Please notice that I am not working for company that owns SaldeoSMART and this wrapper is not approved by them.

The library was created based on documentation 3.0.22, from 25.03.2019.

Before using it, please make sure you have valid username and token. All operations requires same chunks of information:
- operation path,
- key-value pair of parameters,
- token.

## Versioning (important!)
Before version 1.0.0 I allow myself to introduce breaking changes with each release of new MINOR version (read version number as MAJOR.MINOR.PATCH). I will not introduce breaking changes to new PATCH versions.

Version 0.2.0
- Rename properties to ensure common naming convention.
- Make properties `Supplier` and `Customer` of `Contractor` nullable.
- Remove type `Results`. Now results are returned as array of objects. Added methods that help get results of specified type. Read more about results below.

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

The predefined parameters are:
- `AddCommand(..)`
- `AddCompanyProgramId(..)`
- `AddPolicy(..)`
- `AddRequestId(..)`
- `AddRequestIdBasedOnUtcTime()`
- `AddRequestSignature(..)`
- `AddUsername(..)`

## Results
In most cases results of `POST` operations are returned as collection of elements under common node `<RESULTS>`. To handle multiple types the property `Results` of type `Response` is defined as array of objects. If you don't want to cast results manually, you can use generic method `ResultsOfType<T>()` that does it for you, or use one of predefined methods `ResultsOfTypeX()` like: `ResultsOfTypeArticle()`, `ResultsOfTypeCategory()`.

``` csharp
var requestResult = api.PostAsync(...); // Make any API call of type POST.
var response = requestResult.Deserialize(); // Deserialize results into object of type Response.
var resultsAsObjects = response.Results; // Get results as array of objects.
var resultsAsDocuments = response.ResultsOfType<Document>(); // Get strongly typed results of specified type T.
var resultsAsDocuments2 = response.ResultsOfTypeDocument(); // Get stronly typed results of type Document.
```

The methods that return strongly typed results don't throw exception. When property `Results` is euqal to `null` they return empty sequence of specified type.
