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
    public class RoomClientTests
    {
        private Mock<IRoomClient> _roomClient;
        private JsonSerializerSettings jsonSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _roomClient = new Mock<IRoomClient>();
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

            _roomClient.Setup(x => x.GetMemberProfile(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<LineClientResult<Profile>>(apiResponse));

            // Execute
            Task<LineClientResult<Profile>> response = _roomClient.Object.GetMemberProfile("userId", "roomId");

            var result = response.Result;

            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(result, jsonSettings), "{\"response\":{\"userId\":\"\",\"displayName\":\"\",\"pictureUrl\":\"\"},\"statusCode\":0,\"isSuccessStatusCode\":false}");
        }

    }
}
