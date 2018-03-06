using System.Net.Http;

namespace LineBotKit.WebAPI.Model { 
    
public interface ILineApiResponse
    {
        HttpResponseMessage Response { get; }
        ILineApiRequest Request { get; }
    }
}