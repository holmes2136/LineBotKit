using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LineBotKit.WebAPI;
using LineBotKit.Common.Model;
using System.Threading.Tasks;
using LineBotKit.Common.Model.Message;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace LineBotKit.Client.UnitTests
{
    [TestClass]
    public class MessageClientTests
    {
        private Mock<ILineApiClient> _webApiClient;
        private Mock<IMessageClient> _messagClient;
        private JsonSerializerSettings jsonSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _webApiClient = new Mock<ILineApiClient>();
            _messagClient = new Mock<IMessageClient>();

            jsonSettings = new JsonSerializerSettings()
             {
                 ContractResolver = new CamelCasePropertyNamesContractResolver(),
                 NullValueHandling = NullValueHandling.Ignore
             };

            jsonSettings.Converters.Add(new StringEnumConverter(true));

        }

        [TestMethod]
        public void PushMessage_RequestTest()
        {

            _messagClient.Setup(x => x.PushMessage(It.IsAny<PushMessageRequest>())).Returns(Task.FromResult<ResponseItem>(new ResponseItem()));

            // Execute
            Task<ResponseItem> response = _messagClient.Object.PushMessage(new PushMessageRequest());

            ResponseItem result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

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
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"text\":\"text\",\"type\":\"text\"}]}");
        }

        [TestMethod]
        public void PushImageMessageRequest_JsonFormatTest()
        {
            PushMessageRequest request = new PushMessageRequest()
            {
                to = "user id",
                messages = new List<Message>() {
                      new ImageMessage("orginally content url","preview image url")
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"originalContentUrl\":\"orginally content url\",\"previewImageUrl\":\"preview image url\",\"type\":\"image\"}]}");
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
                      new AudioMessage(orginallyContentUrl,duration)
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"originalContentUrl\":\"https://test.m4a\",\"duration\":4000,\"type\":\"audio\"}]}");
        }

        [TestMethod]
        public void MulticastAsync_RequestTest()
        {

            _messagClient.Setup(x => x.MulticastAsync(It.IsAny<MultiCastMessageRequest>())).Returns(Task.FromResult<ResponseItem>(new ResponseItem()));

            // Execute
            Task<ResponseItem> response = _messagClient.Object.MulticastAsync(new MultiCastMessageRequest());

            ResponseItem result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void MulticastAsyncRequest_JsonFormatTest()
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
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":[\"test user\"],\"messages\":[{\"text\":\"test text\",\"type\":\"text\"}]}");
        }

        [TestMethod]
        public void ReplyMessage_RequestTest()
        {

            _messagClient.Setup(x => x.ReplyMessage(It.IsAny<ReplyMessageRequest>())).Returns(Task.FromResult<ResponseItem>(new ResponseItem()));

            // Execute
            Task<ResponseItem> response = _messagClient.Object.ReplyMessage(new ReplyMessageRequest());

            ResponseItem result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ReplyTextMessage_JsonFormatTest()
        {
            ReplyMessageRequest request = new ReplyMessageRequest()
            {
                 replyToken = "reply token",
                 messages = new List<Message>() {
                      new TextMessage("test text")
                 }
            };

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"replyToken\":\"reply token\",\"messages\":[{\"text\":\"test text\",\"type\":\"text\"}]}");
        }

    }
}
