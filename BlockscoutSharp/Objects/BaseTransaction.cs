using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class BaseTransaction
    {
        [JsonProperty("blockNumber")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long BlockNumber { get; set; }

        [JsonProperty("confirmations")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Confirmations { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("gasUsed")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long GasUsed { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(ParseTimestampStringConverter))]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("value")]
        [JsonConverter(typeof(ParseBalanceStringConverter))]
        public Balance Value { get; set; }
    }
}
