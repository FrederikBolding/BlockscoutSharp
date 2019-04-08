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
        [JsonConverter(typeof(ParseStringConverter))]
        public long BlockNumber { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("errCode")]
        public string ErrCode { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("gas")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Gas { get; set; }

        [JsonProperty("gasUsed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long GasUsed { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("isError")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long IsError { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TimeStamp { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}