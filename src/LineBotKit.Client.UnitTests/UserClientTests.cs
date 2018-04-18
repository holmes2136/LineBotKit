using LineBotKit.Client.Response;
using LinetBotKit.Common.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace LineBotKit.Client.UnitTests
{
    [TestClass]
    public class UserClientTests
    {
        private Mock<IUserClient> _userClient;
        private JsonSerializerSettings jsonSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _userClient = new Mock<IUserClient>();
            jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            jsonSettings.Converters.Add(new StringEnumConverter(true));
        }

        [TestMethod]
        public void GetUserProfile_JsonFormatTest()
        {
            var apiResponse = new LineClientResult<Profile>()
            {
                Response = new Profile()
                {
                    displayName = "",
                    pictureUrl = "",
                    userId = ""
                }
            };

            _userClient.Setup(x => x.GetProfile(It.IsAny<string>())).Returns(Task.FromResult<LineClientResult<Profile>>(apiResponse));

            // Execute
            Task<LineClientResult<Profile>> response = _userClient.Object.GetProfile("user id");

            var result = response.Result.Response;

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(result), "{\"userId\":\"\",\"displayName\":\"\",\"pictureUrl\":\"\"}");
        }
    }
}
