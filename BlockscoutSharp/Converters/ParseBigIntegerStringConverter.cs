using Newtonsoft.Json;
using System;
using System.Numerics;

namespace BlockscoutSharp.Converters
{
    public class ParseBigIntegerStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BigInteger) || t == typeof(BigInteger?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            BigInteger i;
            if (BigInteger.TryParse(value, out i))
            {
                return i;
            }
            throw new Exception("Cannot unmarshal type BigInteger");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BigInteger)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseLongStringConverter Singleton = new ParseLongStringConverter();
    }
}