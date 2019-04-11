using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class TransactionInfo
    {
        [JsonProperty("blockNumber")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long BlockNumber { get; set; }

        [JsonProperty("confirmations")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Confirmations { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("gasLimit")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long GasLimit { get; set; }

        [JsonProperty("gasUsed")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long GasUsed { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("logs")]
        public List<TransactionLogEntry> Logs { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long TimeStamp { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("value")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Value { get; set; }
    }

    public class TransactionLogEntry
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("topics")]
        public List<string> Topics { get; set; }
    }
}
