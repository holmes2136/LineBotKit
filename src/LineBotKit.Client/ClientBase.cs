using LineBotKit.Common.Model;
using LineBotKit.WebAPI.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LineBotKit.WebAPI;
using LineBotKit.WebAPI.Model;

namespace LineBotKit.Client
{
    public abstract class ClientBase
    {
        protected const string ApiName = "https://api.line.me";
        protected SemanticVersion SemanticVersion = new SemanticVersion("v2");
        public string ChannelAccessToken { get; set; }
        public HttpClient apiRequest;

        public ClientBase()
        {
            this.apiRequest = new HttpClient();
            this.apiRequest.BaseAddress = new Uri(ApiName);
        }


        protected static async Task<T> ExecuteApiCallAsync<T>(LineApiRequest request)
        {
            using (var client = new LineApiClient())
            {
                ILineApiResponse apiResponse = await client.ExecuteAsync(request).ConfigureAwait(false);

                if (apiResponse == null)
                {
                    throw new Exception(
                        string.Format($"The {ApiName} did not return a response."));
                }

                string content = string.Empty;

                if (apiResponse.Response.Content != null)
                {
                    content = await apiResponse.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }

                if (apiResponse.Response.IsSuccessStatusCode)
                {
                    if (content == "{}" || content == "") {
                        return default(T);
                    }
                    if (!string.IsNullOrEmpty(content))
                    {
                        return JsonConvert.DeserializeObject<T>(content);
                    }
                }

                switch (apiResponse.Response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return JsonConvert.DeserializeObject<T>(content);
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("Not Found");
                    case HttpStatusCode.Unauthorized:
                        throw new UnauthorizedAccessException(
                            string.Format($"Unauthorized response."));
                    default:
                        throw new Exception(string.Format(CultureInfo.InvariantCulture,
                            $"Unknown response. Status Code: {apiResponse.Response.StatusCode}"));
                }
            }
        }

        protected static Stream ExecuteStreamServiceCall(LineApiRequest request)
        {
            using (var client = new LineApiClient())
            {
                ILineApiResponse apiResponse = client.Execute(request);

                if (apiResponse != null)
                {
                    if (apiResponse.Response.IsSuccessStatusCode)
                    {
                        Stream content = apiResponse.Response.Content.ReadAsStreamAsync().Result;

                        content.Seek(0, SeekOrigin.Begin);
                        MemoryStream st = new MemoryStream();
                        content.CopyTo(st);
                        st.Seek(0, SeekOrigin.Begin);

                        return st;
                    }
                    else if (apiResponse.Response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new InvalidDataException(apiResponse.Response.Content.ReadAsStringAsync().Result);
                    }
                    else if (apiResponse.Response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException("Unauthorized response");
                    }

                    throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unknown response. Status Code: {0}", apiResponse.Response.StatusCode));
                }

                throw new Exception("Did not return a response.");
            }
        }
    }

}

