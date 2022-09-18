using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UTMMAX.Core.Json
{
    public static class DefaultSerializer
    {
        public static readonly JsonSerializerSettings Options             = ApplyOptions(new JsonSerializerSettings());
        public static readonly JsonSerializer         CamelCaseSerializer = JsonSerializer.Create(Options);

        public static JsonSerializerSettings ApplyOptions(JsonSerializerSettings options)
        {
            options.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
            options.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            return options;
        }
    }
}