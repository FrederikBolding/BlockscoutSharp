using BlockscoutSharp;
using BlockscoutSharp.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlockscoutSharpTests
{
    [TestClass]
    public class AccountTests
    {
        public BlockscoutClient client = new BlockscoutClient();

        [TestMethod]
        public void GetBalanceTest()
        {
            var balance = client.GetBalance(API.ETH_Mainnet, "0xe77162b7d2ceb3625a4993bab557403a7b706f18").Result;
            Assert.AreEqual(RequestStatus.OK, balance.Status);
            Assert.IsTrue(balance.Result > 0);
        }

        [TestMethod]
        public void GetTransactionsTest()
        {
            var transactions = client.GetTransactions(API.ETH_Mainnet, "0xe77162b7d2ceb3625a4993bab557403a7b706f18").Result;
            Assert.AreEqual(RequestStatus.OK, transactions.Status);
            Assert.IsTrue(transactions.Result.Count > 0);
        }

        [TestMethod]
        public void GetInternalTransactionsTest()
        {
            var transactions = client.GetInternalTransactions(API.ETH_Mainnet, "0xca3595afaafdf3a6773ea34276a3eac026ec36f493287c2fa7153214f4fc0a20").Result;
            Assert.AreEqual(RequestStatus.OK, transactions.Status);
            Assert.IsTrue(transactions.Result.Count > 0);
            Assert.AreEqual(2300, transactions.Result[1].Gas);
        }

        [TestMethod]
        public void GetTokenBalanceTest()
        {
            var balance = client.GetTokenBalance(API.ETH_Mainnet, "", "0xe77162b7d2ceb3625a4993bab557403a7b706f18").Result;
            Assert.AreEqual(RequestStatus.OK, balance.Status);
            Assert.IsTrue(balance.Result > 0);
        }
    }
}