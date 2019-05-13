using BlockscoutSharp;
using BlockscoutSharp.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharpTests
{
    [TestClass]
    public class EtherscanTest
    {
        public BlockscoutClient client = new BlockscoutClient("https://api.etherscan.io", true);

        [TestMethod]
        public void GetBalanceTest()
        {
            var balance = client.GetBalance(API.ETH_Mainnet, "0xe77162b7d2ceb3625a4993bab557403a7b706f18").Result;
            Assert.AreEqual(RequestStatus.OK, balance.Status);
            Assert.IsTrue(balance.Result.eth > 0);
        }

    }
}
