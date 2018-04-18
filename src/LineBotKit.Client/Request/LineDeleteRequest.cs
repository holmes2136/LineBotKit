using LineBotKit.Client.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LineBotKit.Client.Request
{
    internal class LineDeleteRequest<T> : LineClientRequestBase
    {
        public LineDeleteRequest(LineClientBase client, string path) : base(client, path, HttpMethod.Delete)
        {
        }

        public Task<LineClientResult<T>> Execute(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.Execute<T>(null, cancellationToken);
        }
    }
}
