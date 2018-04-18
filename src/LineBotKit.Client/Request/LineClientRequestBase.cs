using LineBotKit.Client.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LineBotKit.Client.Request
{
    internal abstract class LineClientRequestBase
    {
        protected const string LineApiEndpoint = "https://api.line.me";
        protected const string LineSemanticVersion = "v2";
        public LineClientBase Client { get; set; }
        public HttpMethod Method { get; set; }
        public string Path { get; set; }
        public List<KeyValuePair<string, string>> Params { get; set; } = new List<KeyValuePair<string, string>>();
        public string Body { get; set; }
        public Stream ResponseStream { get; set; }


        protected LineClientRequestBase(LineClientBase client, string path, HttpMethod method)
        {
            Client = client;
            Path = path;
            Method = method;
        }

        public async Task<LineClientResult<T>> Execute<T>(object body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = new LineClientResult<T>();

            var url = await BuildUri(Path, Params).ConfigureAwait(false);

            Client.CheckDisposed();

            var message = new HttpRequestMessage(Method, url);

            BuildBodyContent(message, body);

            var response = await Client.HttpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);

            ResponseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.NotFound && !response.IsSuccessStatusCode)
            {
                if (ResponseStream == null)
                {
                    throw new ArgumentException($"Unexpected response, status code {response.StatusCode}");
                }
            }

            result.Response = Deserialize<T>(ResponseStream);
            result.IsSuccessStatusCode = response.IsSuccessStatusCode;
            result.StatusCode = response.StatusCode;

            return result;
        }

        public async Task<LineClientResult<Stream>> ExecuteStreamServiceCall<T>(object body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = new LineClientResult<T>();

            var url = await BuildUri(Path, Params).ConfigureAwait(false);

            Client.CheckDisposed();

            var message = new HttpRequestMessage(Method, url);

            BuildBodyContent(message, body);

            var response = await Client.HttpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);

            ResponseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                Stream content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                content.Seek(0, SeekOrigin.Begin);
                MemoryStream st = new MemoryStream();
                content.CopyTo(st);
                st.Seek(0, SeekOrigin.Begin);

                return new LineClientResult<Stream>()
                {
                    IsSuccessStatusCode = response.IsSuccessStatusCode,
                    Response = st,
                    StatusCode = response.StatusCode
                };
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new InvalidDataException(response.Content.ReadAsStringAsync().Result);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Unauthorized response");
            }
            throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unknown response. Status Code: {0}", response.StatusCode));
        }

        protected virtual void BuildBodyContent(HttpRequestMessage message, object body){}

        protected virtual async Task<Uri> BuildUri(string url, List<KeyValuePair<string, string>> queryParams)
        {
            await Task.Delay(100);

            var address = new Uri($"{LineApiEndpoint}/{LineSemanticVersion}/{url}");

            var builder = new UriBuilder(address.Scheme, address.Host, address.Port,address.PathAndQuery);

            var p = new List<string>();

            if (queryParams != null) {

                foreach (KeyValuePair<string, string> pair in queryParams)
                {
                    p.Add(!string.IsNullOrEmpty(pair.Value)
                        ? $"{Uri.EscapeDataString(pair.Key)}={Uri.EscapeDataString(pair.Value)}"
                        : Uri.EscapeDataString(pair.Key));
                }

            }

            builder.Query = string.Join("&", p);
            return builder.Uri;
        }

        protected TOut Deserialize<TOut>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return Client.Serializer.Deserialize<TOut>(jsonReader);
            }
        }

        protected byte[] Serialize(object value)
        {
            return System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value));
        }

    }
}
