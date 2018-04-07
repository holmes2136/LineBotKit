﻿using System;
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
            string address = "〒150-0002 東京都渋谷区渋谷２丁目２１−１";
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
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"to\":\"user id\",\"messages\":[{\"type\":\"location\",\"latitude\":35.65910807942215,\"longitude\":139.70372892916203,\"title\":\"my location\",\"address\":\"〒150-0002 東京都渋谷区渋谷２丁目２１−１\"}]}");
        }

        [TestMethod]
        public void MulticastMessage_RequestTest()
        {

            _messagClient.Setup(x => x.MulticastMessage(It.IsAny<MultiCastMessageRequest>())).Returns(Task.FromResult<ResponseItem>(new ResponseItem()));

            // Execute
            Task<ResponseItem> response = _messagClient.Object.MulticastMessage(new MultiCastMessageRequest());

            ResponseItem result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

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
            Assert.AreEqual<string>(JsonConvert.SerializeObject(request, Formatting.None, jsonSettings), "{\"replyToken\":\"reply token\",\"messages\":[{\"type\":\"text\",\"text\":\"test text\"}]}");
        }

    }
}