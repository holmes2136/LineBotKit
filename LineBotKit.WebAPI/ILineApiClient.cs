using System;
using System.Threading.Tasks;
using LineBotKit.WebAPI.Model;

namespace LineBotKit.WebAPI
{
    public interface ILineApiClient : IDisposable
    {
        ILineApiResponse Execute(ILineApiRequest webApiRequest);

        Task<ILineApiResponse> ExecuteAsync(ILineApiRequest webApiRequest);

    }
}