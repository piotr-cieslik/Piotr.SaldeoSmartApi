using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests
{
    public sealed class ApiTests
    {
        private Api _api;
        private TestHttpMessageHandler _fakeHttpHandler;

        public ApiTests()
        {
            _fakeHttpHandler = new TestHttpMessageHandler();
            _api =
                new Api(
                    new Uri("https://192.168.0.1"),
                    new HttpClient(_fakeHttpHandler));
        }

        [Fact]
        public async Task GetRequestShouldContainQueryString()
        {
            // Given
            var parameters =
                new Parameters()
                    .AddUsername("user")
                    .AddRequestId("1");
            
            // When
            await _api.GetAsync(
                Path(),
                parameters,
                Token());

            // Then
            // Match if uri contains query string.
            // It should contains following parameters in any order:
            // - username,
            // - req_id,
            // - req_sig
            // in any order.
            // The regex check pattern ?[any]=[any]&[any]=[any]&[any]=[any].
            Assert.Matches(
                "\\?.*\\=.*\\&.*\\=.*\\&.*\\=.*",
                _fakeHttpHandler.Uri.ToString());
            Assert.Contains(
                "username=user",
                _fakeHttpHandler.Uri.ToString());
            Assert.Contains(
                "req_id=1",
                _fakeHttpHandler.Uri.ToString());
            Assert.Contains(
                "req_sig=",
                _fakeHttpHandler.Uri.ToString());
        }

        [Fact]
        public async Task GetRequestShouldCorrectMergeServerAndPath()
        {
            await _api.GetAsync(
                Path(),
                new Parameters(),
                Token());
            // It's important that address doesn't contain doubled slash like "//api"
            Assert.Contains("https://192.168.0.1/api", _fakeHttpHandler.Uri.ToString());
        }

        [Fact]
        public async Task PostRequestShouldContainQueryString()
        {
            // Given
            var parameters =
                new Parameters()
                    .AddUsername("user")
                    .AddRequestId("1")
                    .AddCommand("xml");

            // When
            await _api.PostAsync(
                Path(),
                parameters,
                Token());

            // Then
            // The regex check pattern ?[any]=[any]&[any]=[any]&[any]=[any]&[any]=[any].
            Assert.Matches(
                "\\?.*\\=.*\\&.*\\=.*\\&.*\\=.*&.*\\=.*",
                _fakeHttpHandler.Uri.ToString());
            Assert.Contains(
                "username=user",
                _fakeHttpHandler.Uri.ToString());
            Assert.Contains(
                "req_id=1",
                _fakeHttpHandler.Uri.ToString());
            Assert.Contains(
                "req_sig=",
                _fakeHttpHandler.Uri.ToString());
            Assert.Contains(
                "command=",
                _fakeHttpHandler.Uri.ToString());
        }

        [Fact]
        public async Task PostRequestShouldNotContainContent()
        {
            // Given
            var parameters =
                new Parameters();

            // When
            await _api.PostAsync(
                Path(),
                parameters,
                Token());

            // Then
            Assert.Empty(await _fakeHttpHandler.HttpContent.ReadAsByteArrayAsync());
        }

        [Fact]
        public async Task PostRequestShouldCorrectMergeServerAndPath()
        {
            await _api.PostAsync(
                Path(),
                new Parameters(),
                Token());
            // It's important that address doesn't contain doubled slash like "//api"
            Assert.Contains("https://192.168.0.1/api", _fakeHttpHandler.Uri.ToString());
        }



        private string Path() => "/api/xml/1.0/operation";

        private Token Token() => new Token("1234");

        internal sealed class TestHttpMessageHandler : HttpMessageHandler
        {
            private bool _sent;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (_sent)
                {
                    throw new InvalidOperationException("Cannot send second request.");
                }

                _sent = true;
                Uri = request.RequestUri;
                HttpContent = request.Content;
                var response = new HttpResponseMessage();
                return Task.FromResult(response);
            }

            public Uri Uri { get; private set; }

            public HttpContent HttpContent  { get; private set; }
        }
    }

}
