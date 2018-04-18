using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IAuthenticateClient
    {
        Task<LineClientResult<AccessTokenResponse>> IssueToken(IssueTokenRequest issueTokenRequest);
        Task<LineClientResult<ResponseItem>> RevokeToken(string token);
    }
}
