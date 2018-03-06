using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LineBotKit.WebAPI;
using Moq;
using System.Threading.Tasks;
using LineBotKit.Common.Model;
using Newtonsoft.Json;

namespace LineBotKit.Client.UnitTests
{
    /// <summary>
    /// Summary description for RoomClientTests
    /// </summary>
    [TestClass]
    public class RoomClientTests
    {
        private Mock<ILineApiClient> _webApiClient;
        private Mock<IRoomClient> _roomClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _webApiClient = new Mock<ILineApiClient>();
            _roomClient = new Mock<IRoomClient>();

        }

        [TestMethod]
        public void Leave_RequestTest()
        {

            _roomClient.Setup(x => x.Leave(It.IsAny<string>())).Returns(Task.FromResult<bool>(true));

            // Execute
            Task<bool> response = _roomClient.Object.Leave("43214");

            bool result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetMemberProfile_RequestTest()
        {

            _roomClient.Setup(x => x.GetMemberProfile(It.IsAny<string>(),It.IsAny<string>())).Returns(Task.FromResult<Profile>(new Profile()));

            // Execute
            Task<Profile> response = _roomClient.Object.GetMemberProfile("userId","roomId");

            Profile result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetMemberProfile_JsonFormatTest()
        {
            _roomClient.Setup(x => x.GetMemberProfile(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Profile>(new Profile()));

            // Execute
            Task<Profile> response = _roomClient.Object.GetMemberProfile("userId", "roomId");

            Profile result = response.Result;

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(result), "{\"userId\":null,\"displayName\":null,\"pictureUrl\":null}");
        }

        [TestMethod]
        public void GetMemberIds_RequestTest()
        {

            _roomClient.Setup(x => x.GetMemberIds(It.IsAny<string>())).Returns(Task.FromResult<ResponseItem>(new ResponseItem()));

            // Execute
            Task<ResponseItem> response = _roomClient.Object.GetMemberIds("roomId");

            ResponseItem result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }
    }
}
