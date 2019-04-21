using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class ETHTransaction : Transaction
    {
        [JsonProperty("txreceipt_status")]
        [JsonConverter(typeof(ParseBooleanStringConverter))]
        public bool TxreceiptStatus { get; set; }

        [JsonProperty("isError")]
        [JsonConverter(typeof(ParseBooleanStringConverter))]
        public bool IsError { get; set; }
    }
}