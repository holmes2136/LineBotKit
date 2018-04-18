using LineBotKit.Client.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LineBotKit.Client.Request
{
    internal class LineGetRequest<T> : LineClientRequestBase
    {
        public LineGetRequest(LineClientBase client, string path) : base(client, path, HttpMethod.Get)
        {
        }

        public Task<LineClientResult<T>> Execute(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.Execute<T>(null, cancellationToken);
        }
    }
}
