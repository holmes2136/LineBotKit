# LineBotKit

### Summary :
Provide function which integrate with Line Messaging api

### Features :
```
-- Provide easy understading interface 
-- Provide interface to implement Ioc
```

### How to initial line bot :
The token string come from Line , developer need to register with Line@ first
```
   LineClientManager clientManager = new LineClientManager("token");

```

## Push Message APIs :

### How to send text message :
```  
   ResponseItem result = await clientManager.PushTextMessage("USER IDEN", "MESSAGE");
```

### How to send image message :
```
   ResponseItem result = await clientManager.PushImageMessage("USER IDEN", 
                                                              "ImageContentUrl", 
                                                              "ImagePreviewUrl");

```

### How to send sticker message :
```
   ResponseItem result = await clientManager.PushStickerMessage("USER IDEN", PackageId, StickerId);
```

### How to send  message to mutiple user :
```
   ResponseItem result = await clientManager.MulticastAsync(List<string> to, List<Message> messages);
```

MulticastAsync

## Reply Message APIs : 

### How to reply text message :
```  
   ResponseItem result = await clientManager.ReplyTextMessage("REPLY TOKEN, "MESSAGE");
```

### How to reply image message :
```  
   ResponseItem result = await clientManager.ReplyImageMessage("REPLY TOKEN", ImageContentUrl, ImagePreviewUr);
```
### How to reply sticker message :
```  
   ResponseItem result = await clientManager.ReplyStickerMessage("REPLY TOKEN", PackageId, StickerId);
```


## Group APIs : 

### Leave Group : 
```  
     ResponseItem result = await clientManager.LeaveGroup("GROUP IDEN");
```

### Get Profile of Group : 
```  
     ResponseItem result = await clientManager.GetGroupMemberProfile("USER IDEN", "GROUP IDEN");
```

### Get Member IDEN of Group : 
```  
     ResponseItem result = await clientManager.GetGroupMemberIds("GROUP IDEN");
```


## Room APIs : 

### Get Profile of Room : 
```  
     ResponseItem result = await clientManager.GetRoomMemberProfile("USER IDEN", "ROOM IDEN");
```

### Get Member IDEN of Room : 
```  
     ResponseItem result = await clientManager.GetRoomMemberIds("ROOM IDEN");
```


### Get Profile : 
```  
     ResponseItem result = await clientManager.GetProfile("USER IDEN");
```






