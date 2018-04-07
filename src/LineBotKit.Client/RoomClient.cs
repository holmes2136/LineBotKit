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
    public class RoomClient: ClientBase, IRoomClient
    {

        public RoomClient(string _ChannelAccessToken)
        {
            this.ChannelAccessToken = _ChannelAccessToken;
        }


        /// <summary>
        /// https://api.line.me/v2/bot/room/{roomId}/leave
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<bool> Leave(string roomId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, string.Format("bot/room/{0}/leave",roomId));
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<bool>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// https://api.line.me/v2/bot/room/{roomId}/member/{userId}
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<Profile> GetMemberProfile(string userId,string roomId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, string.Format("bot/room/{0}/member/{1}",roomId,userId));
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<Profile>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// https://api.line.me/v2/bot/room/{roomId}/members/ids
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<MemberIdensResponse> GetMemberIds(string roomId)
        {
            LineApiRequest request = new LineApiRequest(ApiName, SemanticVersion, HttpMethod.Get, string.Format("bot/room/{0}/members/ids",roomId));
            request.Authorization = this.ChannelAccessToken;
            return await ExecuteApiCallAsync<MemberIdensResponse>(request).ConfigureAwait(false);
        }
        
    }
}
