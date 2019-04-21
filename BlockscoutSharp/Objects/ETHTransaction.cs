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
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long TxreceiptStatus { get; set; }

        [JsonProperty("isError")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long IsError { get; set; }
    }
}