# LineBotKit

### Summary :
Provide function which integrate with Line Messaging api

#### Pre-prepare
Developer need to apply line api token first , you can go to the following link :
```
Where apply the token :https://at.line.me
How to apply and setup instruction : https://dotblogs.com.tw/rexhuang/2017/07/02/120455
```


#### How to initial line bot :
The token string come from we setup above
```
   LineClientManager clientManager = new LineClientManager("token");
```


#### What functionalities do we have
```  
Task<ResponseItem> PushTextMessage(string to , string message);
Task<ResponseItem> PushImageMessage(string to, string imageContentUrl, string imagePreviewUrl);
Task<ResponseItem> PushStickerMessage(string to, int packageId, int stickerId);
Task<ResponseItem> PushMessage(PushMessageRequest pushMessageRequest);
Task<ResponseItem> ReplyTextMessage(string to, string message);
Task<ResponseItem> ReplyImageMessage(string to, string imageContentUrl, string imagePreviewUrl);
Task<ResponseItem> ReplyStickerMessage(string to, int packageId, int stickerId);
Task<ResponseItem> ReplyMessage(ReplyMessageRequest reply);
Task<ResponseItem> MulticastAsync(List<string> to, List<Message> messages);
Task<ResponseItem> LeaveGroup(string groupId);
Task<Profile> GetGroupMemberProfile(string userId, string groupId);
Task<Profile> GetRoomMemberProfile(string userId, string groupId);
Task<ResponseItem> GetGroupMemberIds(string groupId);
Task<ResponseItem> GetRoomMemberIds(string roomId);
Task<Profile> GetProfile(string userId);
``` 






