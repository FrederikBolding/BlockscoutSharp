using System.Linq;
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
            Assert.IsTrue(balance.Result.eth > 0);
        }

        [TestMethod]
        public void GetTransactionsTest()
        {
            var transactions = client.GetTransactions(API.ETH_Mainnet, "0xe77162b7d2ceb3625a4993bab557403a7b706f18").Result;
            Assert.AreEqual(RequestStatus.OK, transactions.Status);
            Assert.IsTrue(transactions.Result.Count > 0);
            Assert.IsTrue(transactions.Result.First().Value.eth > 0);
        }

        [TestMethod]
        public void GetInternalTransactionsTest()
        {
            var transactions = client.GetInternalTransactions(API.ETH_Mainnet, "0xca3595afaafdf3a6773ea34276a3eac026ec36f493287c2fa7153214f4fc0a20").Result;
            Assert.AreEqual(RequestStatus.OK, transactions.Status);
            Assert.IsTrue(transactions.Result.Count > 0);
            Assert.AreEqual(2300, transactions.Result[1].Gas);
            Assert.IsTrue(transactions.Result.Last().Value.eth > 0);
        }

        [TestMethod]
        public void GetTokenTransactionsTest()
        {
            var transactions = client.GetTokenTransactions(API.ETH_Mainnet, "0xc3761eb917cd790b30dad99f6cc5b4ff93c4f9ea", "0xe77162b7d2ceb3625a4993bab557403a7b706f18").Result;
            Assert.AreEqual(RequestStatus.OK, transactions.Status);
            Assert.IsTrue(transactions.Result.Count > 0);
        }

        [TestMethod]
        public void GetTokenBalanceTest()
        {
            var balance = client.GetTokenBalance(API.ETH_Mainnet, "0xc3761eb917cd790b30dad99f6cc5b4ff93c4f9ea", "0xe77162b7d2ceb3625a4993bab557403a7b706f18").Result;
            Assert.AreEqual(RequestStatus.OK, balance.Status);
            Assert.IsTrue(balance.Result.eth > 0);
        }

        [TestMethod]
        public void GetTokenListTest()
        {
            var tokens = client.GetTokenList(API.ETH_Mainnet, "0xe77162b7d2ceb3625a4993bab557403a7b706f18").Result;
            Assert.AreEqual(RequestStatus.OK, tokens.Status);
            Assert.IsTrue(tokens.Result.Count > 0);
            Assert.IsTrue(tokens.Result.Any(t => t.ContractAddress.Equals("0xc3761eb917cd790b30dad99f6cc5b4ff93c4f9ea")));
            Assert.IsTrue(tokens.Result.First().Balance.eth > 0);
        }

        // API doesn't seem to respond correctly to this at the moment
        /**[TestMethod]
        public void GetMinedBlocksTest()
        {
            var blocks = client.GetMinedBlocks(API.ETH_Mainnet, "0x005e288d713a5fb3d7c9cf1b43810a98688c7223").Result;
            Assert.AreEqual(RequestStatus.OK, blocks.Status);
            Assert.IsTrue(blocks.Result.Count > 0);
            Assert.IsTrue(blocks.Result.Any(t => t.BlockNumber.Equals(7533047)));
        }**/
    }
}