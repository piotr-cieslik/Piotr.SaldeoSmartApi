using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Piotr.SaldeoSmartApi
{
    public sealed class Api
        : IDisposable
    {
        private readonly Uri _server;
        private readonly HttpClient _httpClient;

        public Api(Uri server)
            : this(server, new HttpClient())
        {
        }

        internal Api(Uri server, HttpClient httpClient)
        {
            // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
            // https://docs.microsoft.com/pl-pl/dotnet/api/system.net.http.httpclient?view=netcore-2.2
            _httpClient = httpClient;
            _server = server;
        }

        /// <summary>
        /// Calculate request signature and perform GET request as an asynchronous operation.
        /// </summary>
        /// <param name="operationPath">Operation path without host information. For example "/api/xml/1.0/company/list".</param>
        /// <param name="parameters">Parameters of request, they are passed to service as query string. They are also used to calculate request signature.</param>
        public async Task<HttpResponseMessage> GetAsync(
            string operationPath,
            Parameters parameters,
            Token token)
        {
            var signature =
                new Signature(token, parameters);
            var signedQueryString =
                new QueryString(parameters.AddRequestSignature(signature));
            var url =
                Url(operationPath, signedQueryString);
            return await _httpClient.GetAsync(url);
        }

        /// <summary>
        /// Calculate request signature and perform POST request as an asynchronous operation.
        /// </summary>
        /// <param name="operationPath">Operation path without host information. For example "/api/xml/1.0/company/list".</param>
        /// <param name="parameters">Parameters of request, they are passed to service as query string. They are also used to calculate request signature.</param>
        public async Task<HttpResponseMessage> PostAsync(
            string operationPath,
            Parameters parameters,
            Token token)
        {
            var signature =
                new Signature(token, parameters);
            // Solution taken from https://stackoverflow.com/a/51854330
            var encodedItems =
                parameters
                    .AddRequestSignature(signature)
                    .Select(x => WebUtility.UrlEncode(x.Key) + "=" + WebUtility.UrlEncode(x.Value));
            var encodedContent =
                new StringContent(
                    string.Join("&", encodedItems),
                    Encoding.UTF8,
                    "application/x-www-form-urlencoded");
            var url =
                Url(operationPath);
            return await _httpClient.PostAsync(url, encodedContent);
        }

        public void Dispose() => _httpClient.Dispose();

        private string Url(string operationPath, QueryString queryString) => $"{_server.ToString().TrimEnd('/')}/{operationPath.TrimStart('/')}{queryString}";

        private string Url(string operationPath) => $"{_server.ToString().TrimEnd('/')}/{operationPath.TrimStart('/')}";
    }
}
