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

        public async Task<BaseRequest<Balance>> GetBalance(API api, string address)
        {
            var balance = await Request<BaseRequest<Balance>>(api, "account", "balance", $"address={address}", ParseBalanceStringConverter.Singleton).ConfigureAwait(false);
            return balance;
        }

        public async Task<BaseRequest<List<AddressBalance>>> GetBalanceMulti(API api, List<string> addresses)
        {
            var balances = await Request<BaseRequest<List<AddressBalance>>>(api, "account", "balancemulti", $"address={String.Join(",", addresses)}").ConfigureAwait(false);
            return balances;
        }

        public async Task<BaseRequest<List<ETHTransaction>>> GetTransactions(API api, string address)
        {
            var transactions = await Request<BaseRequest<List<ETHTransaction>>>(api, "account", "txlist", $"address={address}").ConfigureAwait(false);
            return transactions;
        }

        public async Task<BaseRequest<List<InternalTransaction>>> GetAddressInternalTransactions(API api, string address)
        {
            var transactions = await Request<BaseRequest<List<InternalTransaction>>>(api, "account", "txlistinternal", $"address={address}").ConfigureAwait(false);
            return transactions;
        }

        public async Task<BaseRequest<List<InternalTransaction>>> GetTransactionInternalTransactions(API api, string txhash)
        {
            var transactions = await Request<BaseRequest<List<InternalTransaction>>>(api, "account", "txlistinternal", $"txhash={txhash}").ConfigureAwait(false);
            return transactions;
        }

        public async Task<BaseRequest<List<TokenTransaction>>> GetTokenTransactions(API api, string address)
        {
            var balance = await Request<BaseRequest<List<TokenTransaction>>>(api, "account", "tokentx", $"address={address}").ConfigureAwait(false);
            return balance;
        }

        public async Task<BaseRequest<List<TokenTransaction>>> GetTokenTransactions(API api, string address, string contractAddress)
        {
            var balance = await Request<BaseRequest<List<TokenTransaction>>>(api, "account", "tokentx", $"address={address}&contractaddress={contractAddress}").ConfigureAwait(false);
            return balance;
        }

        public async Task<BaseRequest<Balance>> GetTokenBalance(API api, string contractAddress, string address)
        {
            var balance = await Request<BaseRequest<Balance>>(api, "account", "tokenbalance", $"contractaddress={contractAddress}&address={address}", ParseBalanceStringConverter.Singleton).ConfigureAwait(false);
            return balance;
        }

        public async Task<BaseRequest<List<Token>>> GetTokenList(API api, string address)
        {
            var tokens = await Request<BaseRequest<List<Token>>>(api, "account", "tokenlist", $"address={address}").ConfigureAwait(false);
            return tokens;
        }

        public async Task<BaseRequest<List<Block>>> GetMinedBlocks(API api, string address)
        {
            var blocks = await Request<BaseRequest<List<Block>>>(api, "account", "getminedblocks", $"address={address}").ConfigureAwait(false);
            return blocks;
        }

        public async Task<BaseRequest<TokenInfo>> GetTokenInfo(API api, string contractaddress)
        {
            var token = await Request<BaseRequest<TokenInfo>>(api, "token", "getToken", $"contractaddress={contractaddress}").ConfigureAwait(false);
            return token;
        }

        public async Task<BaseRequest<BigInteger>> GetTokenSupply(API api, string contractAddress)
        {
            var supply = await Request<BaseRequest<BigInteger>>(api, "stats", "tokensupply", $"contractaddress={contractAddress}").ConfigureAwait(false);
            return supply;
        }

        public async Task<BaseRequest<BigInteger>> GetETHSupply(API api)
        {
            var supply = await Request<BaseRequest<BigInteger>>(api, "stats", "ethsupply", "").ConfigureAwait(false);
            return supply;
        }

        public async Task<BaseRequest<ETHPrice>> GetETHPrice(API api)
        {
            var supply = await Request<BaseRequest<ETHPrice>>(api, "stats", "ethprice", "").ConfigureAwait(false);
            return supply;
        }

        public async Task<BaseRequest<TransactionInfo>> GetTransactionInfo(API api, string txhash)
        {
            var transaction = await Request<BaseRequest<TransactionInfo>>(api, "transaction", "gettxinfo", $"txhash={txhash}").ConfigureAwait(false);
            return transaction;
        }
    }

    public enum API
    {
        ETH_Mainnet, ETH_Ropsten, ETH_Goerli, ETH_Rinkeby, ETH_Kovan, ETC_Mainnet, POA_Core, POA_Sokol, POA_Dai
    }
}