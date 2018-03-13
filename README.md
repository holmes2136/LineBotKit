# LineBotKit

### Summary :
Provide functions which integrate with Line Messaging api

#### Pre-prepare
Developer need to apply line api token first , you can go to the following link :
```
Where apply the token :https://at.line.me
How to apply and setup instruction : https://dotblogs.com.tw/rexhuang/2017/07/02/120455
```

#### Where can we get the library
```
We can download from Nuget or execute the following command in nuget package console

Install-Package LineBotKit.Client -Version 1.0.0

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
Task<ResponseItem> PushAudioMessage(string to, string originalContentUrl, int duration);
Task<ResponseItem> PushVideoMessage(string to, string originalContentUrl, string previewImageUrl);
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

### Quick glimpse what the result looks like
``` 
1. Open the application which under "Simulator"  file
2. Excute the application and change the url with like "http://localhost:port/swagger"
3. You will see the following page

![2018-03-08_225107](https://user-images.githubusercontent.com/4464354/37158499-7baf8904-2326-11e8-9970-310c0f0c9a44.jpg)

``` 




