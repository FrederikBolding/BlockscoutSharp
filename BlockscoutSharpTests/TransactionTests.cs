using BlockscoutSharp;
using BlockscoutSharp.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharpTests
{
    [TestClass]
    public class TransactionTests
    {
        public BlockscoutClient client = new BlockscoutClient();

        [TestMethod]
        public void GetTransactionInfoTest()
        {
            var transaction = client.GetTransactionInfo(API.ETH_Mainnet, "0xa9a2e495f3f17a823db5ba5cb77986625ea590107e4b3caf2517ab11f449bc33").Result;
            Assert.AreEqual(RequestStatus.OK, transaction.Status);
            Assert.AreEqual(7252792, transaction.Result.BlockNumber);
        }
    }
}
