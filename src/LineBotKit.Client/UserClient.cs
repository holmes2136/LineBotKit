using LineBotKit.Client.Request;
using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public class UserClient: Request.LineClientBase,IUserClient
    {
        public UserClient(string channelAccessToken) : base(channelAccessToken)
        {
           
        }

        /// <summary>
        /// Get user profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<LineClientResult<Profile>> GetProfile(string  userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("The property user iden can't not be null");
            }

            var request = new LineGetRequest<Profile>(this, $"bot/profile/{userId}");

            return await request.Execute();
        }
    }
}
