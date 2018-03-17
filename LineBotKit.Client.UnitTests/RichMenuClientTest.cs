using LineBotKit.Common.Model.RichMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBotKit.Client.UnitTests
{
    [TestClass]
    public class RichMenuClientTest
    {
        private Mock<IRichMenuClient> _richMenuClient;
        private JsonSerializerSettings jsonSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _richMenuClient = new Mock<IRichMenuClient>();

            jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            jsonSettings.Converters.Add(new StringEnumConverter(true));
        }

        [TestMethod]
        public void CreateRequest_JsonFormatTest()
        {
            RichMenu richMenu = new RichMenu()
            {
                name = "test",
                richMenuId = "",
                size = new Size() {
                    height = 100,
                    width = 100
                },
                chatBarText = "test",
                selected = false,
                areas = new List<Area>() {
                    new Area(){
                         action = new Common.Model.RichMenu.Action(){
                              data = "i=2&c=3",
                              type = "postback"
                         },
                         bounds = new Bounds(){
                              height = 100,
                              width = 100,
                              x = 2,
                              y = 3
                         }
                    }
                }
            };
            // Verify
            Assert.AreEqual<string>(JsonConvert.SerializeObject(richMenu, Formatting.None, jsonSettings), "{\"richMenuId\":\"\",\"size\":{\"width\":100,\"height\":100},\"selected\":false,\"name\":\"test\",\"chatBarText\":\"test\",\"areas\":[{\"bounds\":{\"x\":2,\"y\":3,\"width\":100,\"height\":100},\"action\":{\"type\":\"postback\",\"data\":\"i=2&c=3\"}}]}");
        }
    }
}
