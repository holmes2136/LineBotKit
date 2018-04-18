using LineBotKit.Client.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LineBotKit.Client.Request
{
    internal class LineGetStreamRequest<T> : LineClientRequestBase
    {
        public LineGetStreamRequest(LineClientBase client, string path) : base(client, path, HttpMethod.Get)
        {
        }

        public Task<LineClientResult<Stream>> Execute(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.ExecuteStreamServiceCall<Stream>(null, cancellationToken);
        }
    }
}
