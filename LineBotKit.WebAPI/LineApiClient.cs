using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LineBotKit.WebAPI.Model;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace LineBotKit.WebAPI
{
 
    public sealed class LineApiClient : ILineApiClient
    {
        private HttpClient _httpClient;
        private HttpRequestMessage _httpRequest;
        private HttpResponseMessage _httpResponse;
       

        public ILineApiResponse Execute(ILineApiRequest webApiRequest)
        {
            if (webApiRequest == null)
            {
                throw new ArgumentNullException(nameof(webApiRequest));
            }

            return ExecuteHttpRequest(webApiRequest).Result;
        }

        public Task<ILineApiResponse> ExecuteAsync(ILineApiRequest webApiRequest)
        {
            if (webApiRequest == null)
            {
                throw new ArgumentNullException(nameof(webApiRequest));
            }

            return Task<ILineApiResponse>.Factory.StartNew(() => Execute(webApiRequest));
        }

      
        public void Dispose()
        {
            _httpResponse?.Dispose();
            _httpRequest?.Dispose();
            _httpClient?.Dispose();
        }

        private static HttpClient BuildHttpClient(ILineApiRequest webApiRequest)
        {

            var requestHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            int timeout = 100000;
            if (webApiRequest.TimeoutMilliseconds.HasValue && webApiRequest.TimeoutMilliseconds.Value > timeout)
            {
                timeout = webApiRequest.TimeoutMilliseconds.Value;
            }

            var httpClient = new HttpClient(requestHandler)
            {
                BaseAddress = new Uri(string.Format("{0}", webApiRequest.ServiceName)),
                Timeout = TimeSpan.FromMilliseconds(timeout)
            };

            return httpClient;
        }

        private  HttpRequestMessage BuildHttpRequest(ILineApiRequest webApiRequest, HttpClient httpClient)
        {

            string requestUri = new Uri(string.Format("{0}{1}/{2}", httpClient.BaseAddress, webApiRequest.Version._version, webApiRequest.Resource)).ToString();

            if (webApiRequest.QueryStringParameters.Any())
            {
                var queryString = string.Join("&", webApiRequest.QueryStringParameters.Select(pair => Uri.EscapeDataString(pair.Key) + "=" + Uri.EscapeDataString(pair.Value)));
                requestUri = string.Format(CultureInfo.InvariantCulture, "{0}?{1}", requestUri, queryString);
            }

            var request = new HttpRequestMessage(webApiRequest.Verb, requestUri);

            //Initial token which from Line corp.
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", webApiRequest.Authorization);

            foreach (var pair in webApiRequest.Headers)
            {
                request.Headers.Add(pair.Key, pair.Value);
            }

            if (webApiRequest.Body != null)
            {
                request.Content = GetContentBodyFromRequest(webApiRequest);
            }

            return request;
        }


        private static HttpContent GetContentBodyFromRequest(ILineApiRequest webApiRequest)
        {

            HttpContent content = null;

            if (webApiRequest.Body != null)
            {
                content = GetStreamContentFromRequest(webApiRequest) ?? GetStringContentFromRequest(webApiRequest);
            }

            return content;
        }


        private static HttpContent GetStreamContentFromRequest(ILineApiRequest webApiRequest)
        {
            var stream = webApiRequest.Body as Stream;

            return stream == null
                ? null
                : new StreamContent(stream);
        }


        private static HttpContent GetStringContentFromRequest(ILineApiRequest webApiRequest)
        {
            string json;

            if (webApiRequest.Body == null)
            {
                json = JsonConvert.SerializeObject(webApiRequest.Body, Formatting.None);
            }
            else
            {
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };
                settings.Converters.Add(new StringEnumConverter(true));
                json = JsonConvert.SerializeObject(webApiRequest.Body, Formatting.None, settings);
            }


            return new StringContent(json, Encoding.UTF8, "application/json");
        }


        private static HttpResponseMessage ProcessHttpResponseMessage(Task<HttpResponseMessage> task)
        {
            if (task.IsFaulted)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = task.Exception?.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            if (task.IsCanceled)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.RequestTimeout
                };
            }

            return task.Result;
        }

        private async Task<ILineApiResponse> ExecuteHttpRequest(ILineApiRequest webApiRequest)
        {
            _httpClient = BuildHttpClient(webApiRequest);
            _httpRequest = BuildHttpRequest(webApiRequest, _httpClient);

            _httpResponse = await _httpClient
                .SendAsync(_httpRequest)
                .ContinueWith(ProcessHttpResponseMessage)
                .ConfigureAwait(false);

            return new LineApiResponse
            {
                Response = _httpResponse,
                Request = webApiRequest
            };
        }
    }
}
