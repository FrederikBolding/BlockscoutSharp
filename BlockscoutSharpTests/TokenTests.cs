using BlockscoutSharp;
using BlockscoutSharp.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharpTests
{
    [TestClass]
    public class TokenTests
    {
        public BlockscoutClient client = new BlockscoutClient();

        [TestMethod]
        public void GetTokenInfoTest()
        {
            var token = client.GetTokenInfo(API.ETH_Mainnet, "0x89d24a6b4ccb1b6faa2625fe562bdd9a23260359").Result;
            Assert.AreEqual(RequestStatus.OK, token.Status);
            Assert.AreEqual("DAI", token.Result.Symbol);
        }
    }
}
