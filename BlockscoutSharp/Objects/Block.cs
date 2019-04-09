using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class Block
    {
        [JsonProperty("blockNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BlockNumber { get; set; }

        [JsonProperty("blockReward")]
        public string BlockReward { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TimeStamp { get; set; }
    }
}