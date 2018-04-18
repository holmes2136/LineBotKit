using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using LinetBotKit.Common.Model.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineBotKit.Client.UnitTests
{
    [TestClass]
    public class MessageClientTests
    {
        private Mock<IMessageClient> _messagClient;
        private JsonSerializerSettings jsonSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _messagClient = new Mock<IMessageClient>();

            jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            jsonSettings.Converters.Add(new StringEnumConverter(true));

        }

        [TestMethod]
        public void PushTextMessageRequest_JsonFormatTest()
        {
            PushMessageRequest request = new PushMessageRequest()
            {
                to = "user id",
                messages = new List<Message>() {
                      new TextMessage("text")
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"type\":\"text\",\"text\":\"text\"}]}");
        }

        [TestMethod]
        public void PushImageMessageRequest_JsonFormatTest()
        {
            string orginallyContentUrl = "https://orginallyContentUrl";
            string previewImageUrl = "https://previewImageUrl";

            PushMessageRequest request = new PushMessageRequest()
            {
                to = "user id",
                messages = new List<Message>() {
                      new ImageMessage(new Uri(orginallyContentUrl),new Uri(previewImageUrl))
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"type\":\"image\",\"originalContentUrl\":\"https://orginallyContentUrl\",\"previewImageUrl\":\"https://previewImageUrl\"}]}");
        }

        [TestMethod]
        public void PushAudioMessageRequest_JsonFormatTest()
        {
            int duration = 4000;
            string orginallyContentUrl = "https://test.m4a";

            PushMessageRequest request = new PushMessageRequest()
            {
                to = "user id",
                messages = new List<Message>() {
                      new AudioMessage(new Uri(orginallyContentUrl),duration)
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"type\":\"audio\",\"originalContentUrl\":\"https://test.m4a\",\"duration\":4000}]}");
        }

        [TestMethod]
        public void PushVideoMessageRequest_JsonFormatTest()
        {
            string originalContentUrl = "https://test.mp4";
            string previewImageUrl = "https://test.jpg";

            PushMessageRequest request = new PushMessageRequest()
            {
                to = "user id",
                messages = new List<Message>() {
                      new VideoMessage(new Uri(originalContentUrl),new Uri(previewImageUrl))
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"type\":\"video\",\"originalContentUrl\":\"https://test.mp4\",\"previewImageUrl\":\"https://test.jpg\"}]}");
        }

        [TestMethod]
        public void PushLocationMessageRequest_JsonFormatTest()
        {
            string title = "my location";
            string address = "〒150-0002 東京都涉谷區2丁木21-1";
            decimal latitude = 35.65910807942215M;
            decimal longitude = 139.70372892916203M;

            PushMessageRequest request = new PushMessageRequest()
            {
                to = "user id",
                messages = new List<Message>() {
                      new LocationMessage(title,address,latitude,longitude)
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"type\":\"location\",\"latitude\":35.65910807942215,\"longitude\":139.70372892916203,\"title\":\"my location\",\"address\":\"〒150-0002 東京都涉谷區2丁木21-1\"}]}");
        }


        [TestMethod]
        public void MulticastMessageRequest_JsonFormatTest()
        {
            MultiCastMessageRequest request = new MultiCastMessageRequest()
            {
                to = new List<string>() {
                    "test user"
                },
                messages = new List<Message>() {
                      new TextMessage("test text")
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":[\"test user\"],\"messages\":[{\"type\":\"text\",\"text\":\"test text\"}]}");
        }

        [TestMethod]
        public void ReplyTextMessage_JsonFormatTest()
        {
            ReplyMessageRequest request = new ReplyMessageRequest()
            {
                replyTokens = new List<string>() {
                    "reply token"
                }
                ,
                messages = new List<Message>() {
                      new TextMessage("test text")
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"replyTokens\":[\"reply token\"],\"messages\":[{\"type\":\"text\",\"text\":\"test text\"}]}");
        }
    }
}
