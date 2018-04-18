using LineBotKit.Client.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LineBotKit.Client.Request
{
    internal class LinePostFormUrlEncodedRequest<T> : LineClientRequestBase
    {
        private const string LineDefaultResponseType = "application/x-www-form-urlencoded";

        public LinePostFormUrlEncodedRequest(LineClientBase client, string path) : base(client, path, HttpMethod.Post)
        {
        }

        public Task<LineClientResult<T>> Execute(object body, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.Execute<T>(body, cancellationToken);
        }

        protected override void BuildBodyContent(HttpRequestMessage message, object body)
        {
            if (Params.Count > 0)
            {
                message.Content = new FormUrlEncodedContent(Params);
            }
        }

        protected override Task<Uri> BuildUri(string url, List<KeyValuePair<string, string>> queryParams)
        {
            return base.BuildUri(url, null);
        }
    }
}
