using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class AddressBalance
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("balance")]
        [JsonConverter(typeof(ParseBalanceStringConverter))]
        public Balance Balance { get; set; }
    }
}
