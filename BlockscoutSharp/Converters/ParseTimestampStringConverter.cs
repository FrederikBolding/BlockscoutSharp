using Newtonsoft.Json;
using System;

namespace BlockscoutSharp.Converters
{
    public class ParseTimestampStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DateTime) || t == typeof(DateTime?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return DateTimeOffset.FromUnixTimeSeconds(l).UtcDateTime;
            }
            throw new Exception("Cannot unmarshal type timestmap");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DateTime)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseTimestampStringConverter Singleton = new ParseTimestampStringConverter();
    }
}