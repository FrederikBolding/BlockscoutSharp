using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class Transaction
    {
        [JsonProperty("value")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Value { get; set; }

        [JsonProperty("txreceipt_status")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TxreceiptStatus { get; set; }

        [JsonProperty("transactionIndex")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TransactionIndex { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TimeStamp { get; set; }

        [JsonProperty("nonce")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Nonce { get; set; }

        [JsonProperty("isError")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long IsError { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("gasUsed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long GasUsed { get; set; }

        [JsonProperty("gasPrice")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long GasPrice { get; set; }

        [JsonProperty("gas")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Gas { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("cumulativeGasUsed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CumulativeGasUsed { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("confirmations")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Confirmations { get; set; }

        [JsonProperty("blockNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BlockNumber { get; set; }

        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }
    }
}