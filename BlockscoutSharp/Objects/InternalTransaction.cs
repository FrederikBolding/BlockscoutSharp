using BlockscoutSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class InternalTransaction
    {
        [JsonProperty("blockNumber")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long BlockNumber { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("errCode")]
        public string ErrCode { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("gas")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Gas { get; set; }

        [JsonProperty("gasUsed")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long GasUsed { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("isError")]
        [JsonConverter(typeof(ParseBooleanStringConverter))]
        public bool IsError { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(ParseTimestampStringConverter))]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        [JsonConverter(typeof(ParseBalanceStringConverter))]
        public Balance Value { get; set; }
    }
}