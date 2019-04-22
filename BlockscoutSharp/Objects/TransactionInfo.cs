using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class TransactionInfo : BaseTransaction
    {
        [JsonProperty("gasLimit")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long GasLimit { get; set; }

        [JsonProperty("logs")]
        public List<TransactionLogEntry> Logs { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
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
