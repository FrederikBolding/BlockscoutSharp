using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class TokenTransaction : Transaction
    {
        [JsonProperty("tokenDecimal")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long TokenDecimal { get; set; }

        [JsonProperty("tokenName")]
        public string TokenName { get; set; }

        [JsonProperty("tokenSymbol")]
        public string TokenSymbol { get; set; }
    }
}