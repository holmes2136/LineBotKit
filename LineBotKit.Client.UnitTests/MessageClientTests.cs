using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LineBotKit.WebAPI;
using LineBotKit.Common.Model;
using System.Threading.Tasks;
using LineBotKit.Common.Model.Message;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LineBotKit.Client.UnitTests
{
    [TestClass]
    public class MessageClientTests
    {
        private Mock<ILineApiClient> _webApiClient;
        private Mock<IMessageClient> _messagClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _webApiClient = new Mock<ILineApiClient>();
            _messagClient = new Mock<IMessageClient>();

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
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request), "{\"to\":\"user id\",\"messages\":[{\"text\":\"text\",\"type\":\"text\"}]}");
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
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request), "{\"to\":\"user id\",\"messages\":[{\"originalContentUrl\":\"orginally content url\",\"previewImageUrl\":\"preview image url\",\"type\":\"image\"}]}");
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
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request), "{\"to\":[\"test user\"],\"messages\":[{\"text\":\"test text\",\"type\":\"text\"}]}");
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
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request), "{\"replyToken\":\"reply token\",\"messages\":[{\"text\":\"test text\",\"type\":\"text\"}]}");
        }

    }
}
