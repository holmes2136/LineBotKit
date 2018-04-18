using LineBotKit.Client.Request;
using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class RoomClient : Request.LineClientBase, IRoomClient
    {
        public RoomClient(string channelAccessToken) : base(channelAccessToken)
        {

        }

        /// <summary>
        /// Leave room
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public  async Task<LineClientResult<ResponseItem>> Leave(string roomId)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                throw new ArgumentException("The property room iden can't not be null");
            }

            var request = new LineGetRequest<ResponseItem>(this, $"bot/room/{roomId}/leave");

            return await request.Execute();
        }

        /// <summary>
        /// Get room member profile
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Profile>> GetMemberProfile(string userId, string roomId)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                throw new ArgumentException("The property user iden can't not be null");
            }

            if (string.IsNullOrEmpty(roomId))
            {
                throw new ArgumentException("The property room iden can't not be null");
            }

            var request = new LineGetRequest<Profile>(this, $"bot/room/{roomId}/member/{userId}");

            return await request.Execute();
        }

        /// <summary>
        /// Get room member idens
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<MemberIdensResponse>> GetMemberIds(string roomId)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                throw new ArgumentException("The property user iden can't not be null");
            }

            var request = new LineGetRequest<MemberIdensResponse>(this, $"bot/room/{roomId}/members/ids");

            return await request.Execute();
        }
    }
}
