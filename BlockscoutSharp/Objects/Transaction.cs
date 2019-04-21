using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class Transaction
    {
        [JsonProperty("blockNumber")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long BlockNumber { get; set; }

        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }


        [JsonProperty("cumulativeGasUsed")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long CumulativeGasUsed { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }


        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(ParseTimestampStringConverter))]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }


        [JsonProperty("gas")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Gas { get; set; }

        [JsonProperty("gasPrice")]
        public string GasPrice { get; set; }

        [JsonProperty("gasUsed")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long GasUsed { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("transactionIndex")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long TransactionIndex { get; set; }

        [JsonProperty("nonce")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Nonce { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("confirmations")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Confirmations { get; set; }

        [JsonProperty("value")]
        [JsonConverter(typeof(ParseBalanceStringConverter))]
        public Balance Value { get; set; }
    }
}
