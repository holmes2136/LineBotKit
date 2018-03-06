using LineBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IRoomClient
    {

        Task<bool> Leave(string roomId);

        Task<Profile> GetMemberProfile(string userId, string roomId);

        Task<ResponseItem> GetMemberIds(string roomId);

    }
}