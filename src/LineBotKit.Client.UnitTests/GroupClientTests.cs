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
    public class GroupClientTests
    {
        private Mock<IGroupClient> _groupClient;
        private JsonSerializerSettings jsonSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _groupClient = new Mock<IGroupClient>();
            jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            jsonSettings.Converters.Add(new StringEnumConverter(true));
        }


        [TestMethod]
        public void GetMemberProfile_JsonFormatTest()
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

            _groupClient.Setup(x => x.GetMemberProfile(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<LineClientResult<Profile>>(apiResponse));

            // Execute
            Task<LineClientResult<Profile>> response = _groupClient.Object.GetMemberProfile("userId", "groupId");

            Profile result = response.Result.Response;

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(result), "{\"userId\":\"\",\"displayName\":\"\",\"pictureUrl\":\"\"}");
        }
    }
}
