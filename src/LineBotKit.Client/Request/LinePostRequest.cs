using LineBotKit.Client.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LineBotKit.Client.Request
{
    internal class LinePostRequest<T> : LineClientRequestBase
    {
        private const string LineDefaultResponseType = "application/json";

        public LinePostRequest(LineClientBase client, string path) : base(client, path, HttpMethod.Post)
        {
        }

        public Task<LineClientResult<T>> Execute(object body, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.Execute<T>(body, cancellationToken);
        }

        protected override void BuildBodyContent(HttpRequestMessage message, object body)
        {
            if (body != null)
            {
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };
                settings.Converters.Add(new StringEnumConverter(true));

                string json = JsonConvert.SerializeObject(body, Formatting.None, settings);

                message.Content = new StringContent(json, Encoding.UTF8, LineDefaultResponseType);
            }
        }
    }
}
