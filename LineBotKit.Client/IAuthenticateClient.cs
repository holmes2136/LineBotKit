using LineBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IAuthenticateClient
    {
        /// <summary>
        /// Issues a short-lived channel access token.
        /// </summary>
        /// <param name="issueTokenRequest"></param>
        /// <returns></returns>
        Task<AccessTokenResponse> IssueToken(IssueTokenRequest issueTokenRequest);

        /// <summary>
        /// Revokes a channel access token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<ResponseItem> RevokeToken(string token);


    }
}
