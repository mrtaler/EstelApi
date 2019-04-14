namespace EstelApi.IntegrationTests.Base.Help
{
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    internal static class JsonConverter
    {
        private static readonly JsonSerializer Serializer = JsonSerializer.CreateDefault(
            new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });


        public static JObject ConvertObject(object o)
        {
            return JObject.FromObject(o, Serializer);
        }

        public static T Deserialize<T>(string json)
        {
            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return Serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}