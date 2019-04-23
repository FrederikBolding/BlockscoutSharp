using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlockscoutSharp.Objects;
using System.Collections.Generic;
using System.Numerics;
using BlockscoutSharp.Converters;

namespace BlockscoutSharp
{
    public class BlockscoutClient
    {
        private string baseUrl = "https://blockscout.com";

        private async Task<T> Request<T>(API api, string module, string action, string query, JsonConverter converter = null)
        {
            var split = api.ToString().Split('_');
            var currency = split[0].ToLower();
            var net = split[1].ToLower();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"{baseUrl}/{currency}/{net}/api?module={module}&action={action}&{query}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    List<JsonConverter> converters = new List<JsonConverter>();
                    if (converter != null)
                    {
                        converters.Add(converter);
                    }
                    return (T)JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
                    {
                        Error = HandleDeserializationError,
                        Converters = converters
                    });
                }
                else
                    return default(T);
            }
        }

        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public async Task<Response<Balance>> GetBalance(API api, string address)
        {
            var balance = await Request<Response<Balance>>(api, "account", "balance", $"address={address}", ParseBalanceStringConverter.Singleton).ConfigureAwait(false);
            return balance;
        }

        public async Task<Response<List<AddressBalance>>> GetBalanceMulti(API api, List<string> addresses)
        {
            var balances = await Request<Response<List<AddressBalance>>>(api, "account", "balancemulti", $"address={String.Join(",", addresses)}").ConfigureAwait(false);
            return balances;
        }

        public async Task<Response<List<ETHTransaction>>> GetTransactions(API api, string address)
        {
            var transactions = await Request<Response<List<ETHTransaction>>>(api, "account", "txlist", $"address={address}").ConfigureAwait(false);
            return transactions;
        }

        public async Task<Response<List<InternalTransaction>>> GetAddressInternalTransactions(API api, string address)
        {
            var transactions = await Request<Response<List<InternalTransaction>>>(api, "account", "txlistinternal", $"address={address}").ConfigureAwait(false);
            return transactions;
        }

        public async Task<Response<List<InternalTransaction>>> GetTransactionInternalTransactions(API api, string txhash)
        {
            var transactions = await Request<Response<List<InternalTransaction>>>(api, "account", "txlistinternal", $"txhash={txhash}").ConfigureAwait(false);
            return transactions;
        }

        public async Task<Response<List<TokenTransaction>>> GetTokenTransactions(API api, string address)
        {
            var balance = await Request<Response<List<TokenTransaction>>>(api, "account", "tokentx", $"address={address}").ConfigureAwait(false);
            return balance;
        }

        public async Task<Response<List<TokenTransaction>>> GetTokenTransactions(API api, string address, string contractAddress)
        {
            var balance = await Request<Response<List<TokenTransaction>>>(api, "account", "tokentx", $"address={address}&contractaddress={contractAddress}").ConfigureAwait(false);
            return balance;
        }

        public async Task<Response<Balance>> GetTokenBalance(API api, string contractAddress, string address)
        {
            var balance = await Request<Response<Balance>>(api, "account", "tokenbalance", $"contractaddress={contractAddress}&address={address}", ParseBalanceStringConverter.Singleton).ConfigureAwait(false);
            return balance;
        }

        public async Task<Response<List<Token>>> GetTokenList(API api, string address)
        {
            var tokens = await Request<Response<List<Token>>>(api, "account", "tokenlist", $"address={address}").ConfigureAwait(false);
            return tokens;
        }

        public async Task<Response<List<Block>>> GetMinedBlocks(API api, string address)
        {
            var blocks = await Request<Response<List<Block>>>(api, "account", "getminedblocks", $"address={address}").ConfigureAwait(false);
            return blocks;
        }

        public async Task<Response<TokenInfo>> GetTokenInfo(API api, string contractaddress)
        {
            var token = await Request<Response<TokenInfo>>(api, "token", "getToken", $"contractaddress={contractaddress}").ConfigureAwait(false);
            return token;
        }

        public async Task<Response<BigInteger>> GetTokenSupply(API api, string contractAddress)
        {
            var supply = await Request<Response<BigInteger>>(api, "stats", "tokensupply", $"contractaddress={contractAddress}").ConfigureAwait(false);
            return supply;
        }

        public async Task<Response<BigInteger>> GetETHSupply(API api)
        {
            var supply = await Request<Response<BigInteger>>(api, "stats", "ethsupply", "").ConfigureAwait(false);
            return supply;
        }

        public async Task<Response<ETHPrice>> GetETHPrice(API api)
        {
            var supply = await Request<Response<ETHPrice>>(api, "stats", "ethprice", "").ConfigureAwait(false);
            return supply;
        }

        public async Task<Response<TransactionInfo>> GetTransactionInfo(API api, string txhash)
        {
            var transaction = await Request<Response<TransactionInfo>>(api, "transaction", "gettxinfo", $"txhash={txhash}").ConfigureAwait(false);
            return transaction;
        }
    }

    public enum API
    {
        ETH_Mainnet, ETH_Ropsten, ETH_Goerli, ETH_Rinkeby, ETH_Kovan, ETC_Mainnet, POA_Core, POA_Sokol, POA_Dai
    }
}