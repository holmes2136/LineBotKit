# LineBotKit

[![GitHub license](https://img.shields.io/badge/license-Apache%202-green.svg)](https://raw.githubusercontent.com/dlemstra/line-bot-sdk-dotnet/master/License.txt)
[![Build status](https://ci.appveyor.com/api/projects/status/gh28puo0n0cv1re3?svg=true)](https://ci.appveyor.com/project/holmes2136/linebotkit)
[![NuGet](https://img.shields.io/badge/nuget-v1.0.6-blue.svg)](https://www.nuget.org/packages/LineBotKit.Client/1.0.6)
[![NuGet](https://img.shields.io/badge/swagger-valid-green.svg)](https://www.nuget.org/packages/LineBotKit.Client/1.0.4)

### Summary :
Provide functions which integrate with Line Messaging api

#### Pre-prepare
Developer need to apply line api token first , you can reference the following link :
```
Where apply the token :https://at.line.me
How to apply and setup instruction : https://dotblogs.com.tw/rexhuang/2017/07/02/120455
```

#### Installation
```

Install-Package LineBotKit.Client -Version 1.0.0

```

#### How to initial line bot :
The token string come from we setup above
```
   ILineClientManager clientManager = new LineClientManager("token");
```

#### Easy sample for send text message :
The token string come from we setup above
```
   ILineClientManager clientManager = new LineClientManager("token");
   clientManager.PushTextMessage("user id","message");
```

#### Provide interface to implement IoC like following
```
  container.RegisterType<ILineClientManager, LineClientManager>(
                  new InjectionConstructor("token"));
```

#### What functionalities do we have
```cs  
//Send message related functions:
Task<ResponseItem> PushTextMessage(string to , string message);
Task<ResponseItem> PushImageMessage(string to, string imageContentUrl, string imagePreviewUrl);
Task<ResponseItem> PushStickerMessage(string to, int packageId, int stickerId);
Task<ResponseItem> PushAudioMessage(string to, string originalContentUrl, int duration);
Task<ResponseItem> PushVideoMessage(string to, string originalContentUrl, string previewImageUrl);
Task<ResponseItem> PushLocationMessage(string to, string title, string address , decimal latitude , decimal longitude);
Task<ResponseItem> PushMessage(PushMessageRequest pushMessageRequest);
Task<ResponseItem> MulticastMessage(List<string> to, List<Message> messages);

//Reply message related functions:
Task<ResponseItem> ReplyTextMessage(string to, string message);
Task<ResponseItem> ReplyImageMessage(string to, string imageContentUrl, string imagePreviewUrl);
Task<ResponseItem> ReplyStickerMessage(string to, int packageId, int stickerId);
Task<ResponseItem> ReplyMessage(ReplyMessageRequest reply);

//Room related functions:
Task<Profile> GetRoomMemberProfile(string userId, string groupId);
Task<MemberIdensResponse> GetRoomMemberIds(string roomId);

//Group related functions:
Task<ResponseItem> LeaveGroup(string groupId);
Task<Profile> GetGroupMemberProfile(string userId, string groupId);
Task<MemberIdensResponse> GetGroupMemberIds(string groupId);

//Profile related functions:
Task<Profile> GetProfile(string userId);

//Rich menu related functions:
Task<RichMenu> GetRichMenu(string richMenuId);
Task<RichMenuIdResponse> CreateRichMenu(RichMenu richMenu);
Task<ResponseItem> DeleteRichMenu(string richMenuId);
Task<RichMenuIdResponse> GetRichMenuByUserId(string userId);
Task<ResponseItem> LinkRichMenuWithUser(string userId, string richMenuId);
Task<ResponseItem> UnLinkRichMenuWithUser(string userId);
Task<RichMenuListResponse> GetRichMenuList();
Task<ResponseItem> SetRichMenuImage(string richMenuId , byte[] image);
Stream GetRichMenuImage(string richMenuId);

//Others : 
Stream GetMessageContent(string messageId);

``` 

#### Examples :
```cs  

//multiple message with different message type

var response = await lineManager.PushMessage(
new PushMessageRequest()
{
  to = "User Iden",
  messages = new List<Message>() {
             new TextMessage("Test first message"),
             new ImageMessage("Orginally Content Url","Preview Image Url")
  }

});
            

//buttons template message

 ResponseItem response = await lineManager.PushMessage(
 new PushMessageRequest()
 {
   to = "User Iden",
   messages = new List<Message>() {
              new TemplateMessage(){
                  altText = "altText",
                  template = new ButtonsTemplate(){
                  text = "text",
                  thumbnailImageUrl = "Thumbnail Image Url",
                  title = "title",
                  actions = new List<TemplateAction>(){
                            new UriAction(){
                                label = "test",
                                uri = "http://www.yahoo.com.tw"
                            }
                  }
              }
              }
  }
});

// Confirm template message

ResponseItem response = await lineManager.PushMessage(
new PushMessageRequest()
{
    to = "User Iden",
    messages = new List<Message>() {
            new TemplateMessage(){
                altText = "altText",
                template = new ConfirmTemplate(){
                    text = "text",
                    actions = new List<TemplateAction>(){
                        new MessageAction(){
                            label = "test",
                            text = "text"
                        },
                            new MessageAction(){
                            label = "test",
                            text = "text"
                        }
                    }
                }
            }
    }
});

//Carousel template message

 ResponseItem response = await lineManager.PushMessage(
 new PushMessageRequest()
 {
     to = "User Iden",
     messages = new List<Message>() {
          new TemplateMessage(){
               altText = "altText",
               template = new CarouselTemplate(){
                    columns = new List<TemplateColumn>(){
                         new TemplateColumn(){
                              title = "title",
                              text = "text",
                              ThumbnailImageUrl = "Thumbnail image url",
                              actions = new  List<TemplateAction>(){
                                     new MessageAction(){
                                          label = "label",
                                          text = "text"
                                     }
                              }
                         }
                    }
               }
          }
     }
 });


```

### Quick glimpse what the result looks like
``` 
1. Open the application which under "Simulator"  file
2. Excute the application and change the url with like "http://localhost:port/swagger"
3. You will see the following page

![2018-03-08_225107](https://user-images.githubusercontent.com/4464354/37158499-7baf8904-2326-11e8-9970-310c0f0c9a44.jpg)

``` 


