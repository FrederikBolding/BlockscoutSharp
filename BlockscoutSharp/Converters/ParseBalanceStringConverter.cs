using BlockscoutSharp.Objects;
using Newtonsoft.Json;
using System;
using System.Numerics;

namespace BlockscoutSharp.Converters
{
    public class ParseBalanceStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Balance);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            BigInteger i = 0;
            if (string.IsNullOrEmpty(value) || BigInteger.TryParse(value, out i))
            {
                return new Balance(i);
            }
            throw new Exception("Cannot unmarshal type Balance");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Balance)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseBalanceStringConverter Singleton = new ParseBalanceStringConverter();
    }
}