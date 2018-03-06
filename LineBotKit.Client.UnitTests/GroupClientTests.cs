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
    /// Summary description for GroupClientTests
    /// </summary>
    [TestClass]
    public class GroupClientTests
    {
        private Mock<ILineApiClient> _webApiClient;
        private Mock<IGroupClient> _groupClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _webApiClient = new Mock<ILineApiClient>();
            _groupClient = new Mock<IGroupClient>();

        }

        [TestMethod]
        public void Leave_RequestTest()
        {

            _groupClient.Setup(x => x.Leave(It.IsAny<string>())).Returns(Task.FromResult<ResponseItem>(new ResponseItem()));

            // Execute
            Task<ResponseItem> response = _groupClient.Object.Leave("groupId");

            ResponseItem result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void GetMemberProfile_RequestTest()
        {

            _groupClient.Setup(x => x.GetMemberProfile(It.IsAny<string>(),It.IsAny<string>())).Returns(Task.FromResult<Profile>(new Profile()));

            // Execute
            Task<Profile> response = _groupClient.Object.GetMemberProfile("userId","groupId");

            Profile result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetMemberProfile_JsonFormatTest()
        {
            _groupClient.Setup(x => x.GetMemberProfile(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Profile>(new Profile()));

            // Execute
            Task<Profile> response = _groupClient.Object.GetMemberProfile("userId", "groupId");

            Profile result = response.Result;

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(result), "{\"userId\":null,\"displayName\":null,\"pictureUrl\":null}");
        }

        [TestMethod]
        public void GetMemberIds_RequestTest()
        {

            _groupClient.Setup(x => x.GetMemberIds(It.IsAny<string>())).Returns(Task.FromResult<ResponseItem>(new ResponseItem()));

            // Execute
            Task<ResponseItem> response = _groupClient.Object.GetMemberIds("groupId");

            ResponseItem result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }
    }
}
