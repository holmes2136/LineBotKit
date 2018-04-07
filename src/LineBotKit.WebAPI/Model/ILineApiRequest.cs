using System.Collections.Generic;
using System.Net.Http;

namespace LineBotKit.WebAPI.Model
{
    public interface ILineApiRequest
    {
        string ServiceName { get; }
       
        SemanticVersion Version { get; }

        HttpMethod Verb { get; }
        
        string Resource { get; }
        
        IDictionary<string, string> Headers { get; }
       
        IQueryStringParameterCollection QueryStringParameters { get; }
       
        object Body { get; }
       
        bool RetryTimeout { get; }
       
        int? TimeoutMilliseconds { get; set; }

        string  Authorization { get; set; }

        HttpContent Content { get; set; }

    }
}