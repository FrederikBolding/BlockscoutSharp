using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class Transaction : BaseTransaction
    {
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("cumulativeGasUsed")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long CumulativeGasUsed { get; set; }

        [JsonProperty("gas")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Gas { get; set; }

        [JsonProperty("gasPrice")]
        [JsonConverter(typeof(ParseBigIntegerStringConverter))]
        public BigInteger GasPrice { get; set; }

        [JsonProperty("transactionIndex")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long TransactionIndex { get; set; }

        [JsonProperty("nonce")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Nonce { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }
    }
}
