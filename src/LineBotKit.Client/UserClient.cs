using LineBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LineBotKit.WebAPI.Model;

namespace LineBotKit.Client
{
    public class UserClient : ClientBase, IUserClient
    {
        public UserClient(string _ChannelAccessToken)
        {
            this.ChannelAccessToken = _ChannelAccessToken;
        }

        /// <summary>
        /// https://api.line.me/v2/bot/profile/{userId}
        /// </summary>
        /// <returns></returns>
        public async Task<Profile> GetProfile(string userId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, string.Format("bot/profile/{0}", userId));
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<Profile>(request).ConfigureAwait(false);
        }

    }
}
