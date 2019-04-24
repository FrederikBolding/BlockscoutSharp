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
        private string baseUrl;

        public BlockscoutClient(string baseUrl = "https://blockscout.com")
        {
            this.baseUrl = baseUrl;
        }

        private async Task<T> Request<T>(Query query, JsonConverter converter = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(query.Build(baseUrl)).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    List<JsonConverter> converters = new List<JsonConverter>();
                    if (converter != null)
                    {
                        converters.Add(converter);
                    }
                    return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
                    {
                        Error = HandleDeserializationError,
                        Converters = converters
                    });
                }
                else
                    return default;
            }
        }

        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public async Task<Response<Balance>> GetBalance(API api, string address)
        {
            Query query = new Query(api, "account", "balance", new KeyValuePair<string, string>("address", address));
            return await Request<Response<Balance>>(query, ParseBalanceStringConverter.Singleton).ConfigureAwait(false);
        }

        public async Task<Response<List<AddressBalance>>> GetBalanceMulti(API api, List<string> addresses)
        {
            Query query = new Query(api, "account", "balance", new KeyValuePair<string, string>("address", String.Join(",", addresses)));
            return await Request<Response<List<AddressBalance>>>(query).ConfigureAwait(false);
        }

        public async Task<Response<List<ETHTransaction>>> GetTransactions(API api, string address)
        {
            Query query = new Query(api, "account", "txlist", new KeyValuePair<string, string>("address", address));
            return await Request<Response<List<ETHTransaction>>>(query).ConfigureAwait(false);
        }

        public async Task<Response<List<InternalTransaction>>> GetAddressInternalTransactions(API api, string address)
        {
            Query query = new Query(api, "account", "txlistinternal", new KeyValuePair<string, string>("address", address));
            return await Request<Response<List<InternalTransaction>>>(query).ConfigureAwait(false);
        }

        public async Task<Response<List<InternalTransaction>>> GetTransactionInternalTransactions(API api, string txhash)
        {
            Query query = new Query(api, "account", "txlistinternal", new KeyValuePair<string, string>("txhash", txhash));
            return await Request<Response<List<InternalTransaction>>>(query).ConfigureAwait(false);
        }

        public async Task<Response<List<TokenTransaction>>> GetTokenTransactions(API api, string address, string contractAddress = "")
        {
            Query query = new Query(api, "account", "tokentx", new KeyValuePair<string, string>("address", address));

            if (!string.IsNullOrEmpty(contractAddress))
            {
                query.AddQueryString("contractAddress", contractAddress);
            }

            return await Request<Response<List<TokenTransaction>>>(query).ConfigureAwait(false);
        }

        public async Task<Response<Balance>> GetTokenBalance(API api, string contractAddress, string address)
        {
            Query query = new Query(api, "account", "tokenbalance", new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("contractaddress", contractAddress), new KeyValuePair<string, string>("address", address) });
            return await Request<Response<Balance>>(query, ParseBalanceStringConverter.Singleton).ConfigureAwait(false);
        }

        public async Task<Response<List<Token>>> GetTokenList(API api, string address)
        {
            Query query = new Query(api, "account", "tokenlist", new KeyValuePair<string, string>("address", address));
            return await Request<Response<List<Token>>>(query).ConfigureAwait(false);
        }

        public async Task<Response<List<Block>>> GetMinedBlocks(API api, string address)
        {
            Query query = new Query(api, "account", "getminedblocks", new KeyValuePair<string, string>("address", address));
            return await Request<Response<List<Block>>>(query).ConfigureAwait(false);
        }

        public async Task<Response<TokenInfo>> GetTokenInfo(API api, string contractAddress)
        {
            Query query = new Query(api, "token", "getToken", new KeyValuePair<string, string>("contractaddress", contractAddress));
            return await Request<Response<TokenInfo>>(query).ConfigureAwait(false);
        }

        public async Task<Response<BigInteger>> GetTokenSupply(API api, string contractAddress)
        {
            Query query = new Query(api, "stats", "tokensupply", new KeyValuePair<string, string>("contractaddress", contractAddress));
            return await Request<Response<BigInteger>>(query).ConfigureAwait(false);
        }

        public async Task<Response<BigInteger>> GetETHSupply(API api)
        {
            Query query = new Query(api, "stats", "ethsupply");
            return await Request<Response<BigInteger>>(query).ConfigureAwait(false);
        }

        public async Task<Response<ETHPrice>> GetETHPrice(API api)
        {
            Query query = new Query(api, "stats", "ethprice");
            return await Request<Response<ETHPrice>>(query).ConfigureAwait(false);
        }

        public async Task<Response<TransactionInfo>> GetTransactionInfo(API api, string txhash)
        {
            Query query = new Query(api, "transaction", "gettxinfo", new KeyValuePair<string, string>("txhash", txhash));
            return await Request<Response<TransactionInfo>>(query).ConfigureAwait(false);
        }
    }

    public enum API
    {
        ETH_Mainnet, ETH_Ropsten, ETH_Goerli, ETH_Rinkeby, ETH_Kovan, ETC_Mainnet, POA_Core, POA_Sokol, POA_Dai
    }
}