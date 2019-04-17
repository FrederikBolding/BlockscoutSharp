using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class TokenInfo
    {
        [JsonProperty("cataloged")]
        public bool Cataloged { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("decimals")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Decimals { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("totalSupply")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long TotalSupply { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
