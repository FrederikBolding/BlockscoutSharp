using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class Token
    {
        [JsonProperty("balance")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Balance { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("decimals")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Decimals { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}