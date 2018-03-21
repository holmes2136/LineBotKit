using LineBotKit.Common.Model;
using LineBotKit.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class AuthenticateClient: ClientBase, IAuthenticateClient
    {
        public AuthenticateClient()
        {

        }

        /// <summary>
        /// Issues a short-lived channel access token.
        /// </summary>
        /// <param name="issueTokenRequest"></param>
        /// <returns></returns>
        public async Task<AccessTokenResponse> IssueToken(IssueTokenRequest issueTokenRequest)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, "/oauth/accessToken", issueTokenRequest);
            //request.Authorization = this.ChannelAccessToken;
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = issueTokenRequest.grant_type,
                ["client_id"] = issueTokenRequest.client_id,
                ["client_secret"] = issueTokenRequest.client_secret
            });
            return await ExecuteApiCallAsync<AccessTokenResponse>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Revokes a channel access token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ResponseItem> RevokeToken(string token)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, "/oauth/revoke");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["access_token"] = token
            });
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }
    }
}
