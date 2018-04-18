using LineBotKit.Client.Request;
using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class GroupClient : Request.LineClientBase, IGroupClient
    {
        public GroupClient(string channelAccessToken) : base(channelAccessToken){}

        /// <summary>
        /// Leave group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<ResponseItem>> Leave(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("The property group iden can't not be null");
            }

            var request = new LinePostRequest<ResponseItem>(this, $"bot/group/{groupId}/leave");

            return await request.Execute(null);
        }

        /// <summary>
        /// Get group member profile
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Profile>> GetMemberProfile(string userId, string groupId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("The property user iden can't not be null");
            }

            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("The property group iden can't not be null");
            }

            var request = new LineGetRequest<Profile>(this, $"bot/group/{groupId}/member/{userId}");

            return await request.Execute();
        }

        /// <summary>
        /// Get group member idens
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<MemberIdensResponse>> GetMemberIds(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("The property group iden can't not be null");
            }

            var request = new LineGetRequest<MemberIdensResponse>(this, $"bot/group/{groupId}/members/ids");

            return await request.Execute();
        }
    }
}
