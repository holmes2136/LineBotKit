using LineBotKit.Client.Request;
using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class AuthenticateClient : Request.LineClientBase,IAuthenticateClient
    {
        public AuthenticateClient(string channelAccessToken) : base(channelAccessToken) { }

        /// <summary>
        /// Issues a short-lived channel access token.
        /// </summary>
        /// <param name="issueTokenRequest"></param>
        /// <returns></returns>
        public async Task<LineClientResult<AccessTokenResponse>> IssueToken(IssueTokenRequest issueTokenRequest)
        {
            if (issueTokenRequest == null)
            {
                throw new ArgumentNullException(nameof(IssueTokenRequest));
            }

            var request = new LinePostFormUrlEncodedRequest<AccessTokenResponse>(this, $"oauth/accessToken");
            request.Params.Add(new KeyValuePair<string,string>("grant_type", issueTokenRequest.grant_type));
            request.Params.Add(new KeyValuePair<string, string>("client_id", issueTokenRequest.client_id));
            request.Params.Add(new KeyValuePair<string, string>("client_secret", issueTokenRequest.client_secret));

            return await request.Execute(issueTokenRequest);
        }

        /// <summary>
        /// Revokes a channel access token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> RevokeToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("The parameter token should not be empty or null");
            }

            var request = new LinePostFormUrlEncodedRequest<ResponseItem>(this, $"oauth/revoke");
            request.Params.Add(new KeyValuePair<string, string>("access_token", token));

            return await request.Execute(null);
        }
    }
}
