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
                ILineApiResponse webApiResponse = await client.ExecuteAsync(request).ConfigureAwait(false);

                if (webApiResponse == null)
                {
                    throw new Exception(
                        string.Format($"The {ApiName} did not return a response.  This is not normal and need to be investigated."));
                }

                string content = string.Empty;

                if (webApiResponse.Response.Content != null)
                {
                    content = await webApiResponse.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }

                if (webApiResponse.Response.IsSuccessStatusCode)
                {
                    if (content == "{}" || content == "") {
                        return default(T);
                    }
                    if (!string.IsNullOrEmpty(content))
                    {
                        return JsonConvert.DeserializeObject<T>(content);
                    }
                }

                switch (webApiResponse.Response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return JsonConvert.DeserializeObject<T>(content);
                        //throw new InvalidDataException("Not Valid");
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("Not Found");
                    case HttpStatusCode.Unauthorized:
                        throw new UnauthorizedAccessException(
                            string.Format($"An Unauthorized response was returned by the {ApiName}."));
                    default:
                        throw new Exception(string.Format(CultureInfo.InvariantCulture,
                            $"The {ApiName} returned an unknown response. Status Code: {webApiResponse.Response.StatusCode}"));
                }
            }
        }
    }

}

