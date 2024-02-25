using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace RatServer.Core.Extensions
{
    public static class ObjectExtension
    {
        public static bool CanBeConverted<T>(this object value) where T : class
        {
            string jsonData = JsonConvert.SerializeObject(value);
            JSchemaGenerator generator = new();
            JSchema parsedSchema = generator.Generate(typeof(T));
            JObject jObject = JObject.Parse(jsonData);

            return jObject.IsValid(parsedSchema);
        }

        public static T ConvertToType<T>(this object value) where T : class
        {
            string jsonData = JsonConvert.SerializeObject(value);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }

}
