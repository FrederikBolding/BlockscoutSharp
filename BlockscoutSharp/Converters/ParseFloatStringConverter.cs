using Newtonsoft.Json;
using System;
using System.Globalization;

namespace BlockscoutSharp.Converters
{
    public class ParseFloatStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(float) || t == typeof(float?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            float f;
            if (float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out f))
            {
                return f;
            }
            throw new Exception("Cannot unmarshal type float");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (float)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseFloatStringConverter Singleton = new ParseFloatStringConverter();
    }
}