using Newtonsoft.Json;
using System;

namespace RatServer.Global.Helpers
{
    public class JsonBooleanConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object value = reader.Value;

            return value != null &&        // when model has true this condition sets value to true
                !string.IsNullOrWhiteSpace(value.ToString()) &&
                Boolean.Equals(value, true)
                ? true
                : value != null &&     // this condition is used to convert x 
                                !string.IsNullOrWhiteSpace(value.ToString()) &&
                                string.Equals(value.ToString().ToLower(), "x")
                    ? true
                    : (object)false;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string) || objectType == typeof(bool);
        }
    }
}
