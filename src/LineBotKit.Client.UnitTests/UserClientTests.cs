using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LineBotKit.WebAPI;
using Moq;
using LineBotKit.WebAPI.Model;
using System.Net.Http;
using System.Net;
using LineBotKit.Common.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LineBotKit.Client.UnitTests
{
    /// <summary>
    /// Summary description for UserClientTests
    /// </summary>
    [TestClass]
    public class UserClientTests
    {
        private Mock<ILineApiClient> _webApiClient;
        private Mock<IUserClient> _userClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _webApiClient = new Mock<ILineApiClient>();
            _userClient = new Mock<IUserClient>();

        }

        [TestMethod]
        public void GetUserProfile_RequestTest()
        {
            _userClient.Setup(x => x.GetProfile(It.IsAny<string>())).Returns(Task.FromResult<Profile>(new Profile()));

            // Execute
            Task<Profile> response = _userClient.Object.GetProfile("user id");
         
            Profile result = response.Result;

            //// Verify
            Assert.IsNotNull(response);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetUserProfile_JsonFormatTest()
        {
            _userClient.Setup(x => x.GetProfile(It.IsAny<string>())).Returns(Task.FromResult<Profile>(new Profile()));

            // Execute
            Task<Profile> response = _userClient.Object.GetProfile("user id");

            Profile result = response.Result;

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(result), "{\"userId\":null,\"displayName\":null,\"pictureUrl\":null}");
        }
    }
}
