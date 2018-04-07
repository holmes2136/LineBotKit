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
    public class GroupClient: ClientBase, IGroupClient
    {
        public GroupClient(string _ChannelAccessToken)
        {
            this.ChannelAccessToken = _ChannelAccessToken;
        }


        /// <summary>
        /// https://api.line.me/v2/bot/group/{groupId}/leave
        /// </summary>
        /// <param name="ToUserID"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public async Task<ResponseItem> Leave(string groupId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Post, string.Format("bot/group/{0}/leave",groupId));
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<ResponseItem>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// https://api.line.me/v2/bot/group/{groupId}/member/{userId}
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<Profile> GetMemberProfile(string userId,string groupId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, string.Format("bot/group/{0}/member/{1}",groupId,userId));
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<Profile>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// https://api.line.me/v2/bot/group/{groupId}/members/ids
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<MemberIdensResponse> GetMemberIds(string groupId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, string.Format("bot/group/{0}/members/ids",groupId));
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<MemberIdensResponse>(request).ConfigureAwait(false);
        }
        
    }
}
