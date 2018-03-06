using System;
using System.Collections.Generic;
using System.Net.Http;

namespace LineBotKit.WebAPI.Model
{
    
    [Serializable]
    public class LineApiRequest : ILineApiRequest
    {
       

        public LineApiRequest(string serviceName, SemanticVersion version, HttpMethod method, string resource, object body = null, bool retryOnTimeout = true)
            : this(method, resource, body, retryOnTimeout)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentNullException(nameof(serviceName));
            }

            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            ServiceName = serviceName;
            Version = version;
        }

        private LineApiRequest(HttpMethod method, string resource, object body, bool RetryOnTimeout)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException(nameof(resource));
            }

            _verb = method.ToString();
            Resource = resource;
            Body = body;

            Headers = new Dictionary<string, string>();
            QueryStringParameters = new QueryStringParameterCollection();
            RetryTimeout = RetryOnTimeout;
        }

        private readonly string _verb;

        public string ServiceName { get; }
       
        public SemanticVersion Version { get; }

       
        public int? TimeoutMilliseconds { get; set; }

        
        public string Authorization { get; set; }

   
        public HttpMethod Verb
        {
            get
            {
                if (_verb == HttpMethod.Delete.ToString())
                {
                    return HttpMethod.Delete;
                }

                if (_verb == HttpMethod.Get.ToString())
                {
                    return HttpMethod.Get;
                }

                if (_verb == HttpMethod.Head.ToString())
                {
                    return HttpMethod.Head;
                }

                if (_verb == HttpMethod.Options.ToString())
                {
                    return HttpMethod.Options;
                }

                if (_verb == HttpMethod.Post.ToString())
                {
                    return HttpMethod.Post;
                }

                if (_verb == HttpMethod.Put.ToString())
                {
                    return HttpMethod.Put;
                }

                return HttpMethod.Trace;
            }
        }

      
        public string Resource { get; }

     
        public IDictionary<string, string> Headers { get; }

      
        public IQueryStringParameterCollection QueryStringParameters { get; }

       
        public object Body { get; }

      
        public bool RetryTimeout { get; }

    }
}
