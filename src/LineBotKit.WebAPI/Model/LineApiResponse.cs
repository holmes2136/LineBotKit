using System.Net.Http;

namespace LineBotKit.WebAPI.Model
{
    public class LineApiResponse : ILineApiResponse
    {
        public HttpResponseMessage Response { get; set; }

        public ILineApiRequest Request { get; set; }
    }
}