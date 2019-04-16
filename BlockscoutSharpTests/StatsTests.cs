using BlockscoutSharp;
using BlockscoutSharp.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlockscoutSharpTests
{
    [TestClass]
    public class StatsTests
    {
        public BlockscoutClient client = new BlockscoutClient();

        [TestMethod]
        public void GetTokenSupplyTest()
        {
            var supply = client.GetTokenSupply(API.ETH_Mainnet, "0x89d24a6b4ccb1b6faa2625fe562bdd9a23260359").Result;
            Assert.AreEqual(RequestStatus.OK, supply.Status);
            Assert.IsTrue(supply.Result > 0);
        }


        [TestMethod]
        public void GetETHSupplyTest()
        {
            var supply = client.GetETHSupply(API.ETH_Mainnet).Result;
            Assert.AreEqual(RequestStatus.OK, supply.Status);
            Assert.IsTrue(supply.Result > 0);
        }

        [TestMethod]
        public void GetETHPriceTest()
        {
            var price = client.GetETHPrice(API.ETH_Mainnet).Result;
            Assert.AreEqual(RequestStatus.OK, price.Status);
            Assert.IsTrue(price.Result.ETHUSD > 0);
            Assert.AreEqual(DateTime.UtcNow.DayOfYear, price.Result.ETHUSDTimestamp.DayOfYear);
        }
    }
}
