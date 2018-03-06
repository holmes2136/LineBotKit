using LineBotKit.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client
{
    public interface IGroupClient
    {

         Task<ResponseItem> Leave(string groupId);

         Task<Profile> GetMemberProfile(string userId, string groupId);

         Task<ResponseItem> GetMemberIds(string groupId);
       
    }
}
