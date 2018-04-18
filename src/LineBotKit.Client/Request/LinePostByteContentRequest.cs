using LineBotKit.Client.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LineBotKit.Client.Request
{
    internal class LinePostByteContentRequest<T> : LineClientRequestBase
    {
        private const string LineDefaultResponseType = "application/json";

        public LinePostByteContentRequest(LineClientBase client, string path) : base(client, path, HttpMethod.Post)
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
                message.Content = new ByteArrayContent((Byte[])body);
                message.Content.Headers.Add("Content-Type", "image/jpeg");
            }
        }
    }
}
