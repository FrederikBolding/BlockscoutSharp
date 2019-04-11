using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class ETHPrice
    {
        [JsonProperty("ethbtc")]
        [JsonConverter(typeof(ParseFloatStringConverter))]
        public float ETHBTC { get; set; }

        [JsonProperty("ethbtc_timestamp")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long ETHBTCTimestamp { get; set; }

        [JsonProperty("ethusd")]
        [JsonConverter(typeof(ParseFloatStringConverter))]
        public float ETHUSD { get; set; }

        [JsonProperty("ethusd_timestamp")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long ETHUSDTimestamp { get; set; }
    }
}
