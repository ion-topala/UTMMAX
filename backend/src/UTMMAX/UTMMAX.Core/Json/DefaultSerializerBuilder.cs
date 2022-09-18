using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UTMMAX.Core.Json
{
    public class DefaultSerializerBuilder
    {
        private JsonSerializerSettings _settings;

        private DefaultSerializerBuilder()
        {
            _settings = new JsonSerializerSettings();
            DefaultSerializer.ApplyOptions(_settings);
        }

        public static DefaultSerializerBuilder Create()
        {
            return new DefaultSerializerBuilder();
        }

        public DefaultSerializerBuilder IgnoreMissing()
        {
            _settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            return this;
        }

        public DefaultSerializerBuilder IgnoreNullValues()
        {
            _settings.NullValueHandling = NullValueHandling.Ignore;

            return this;
        }

        public DefaultSerializerBuilder WithContractResolver(IContractResolver resolver)
        {
            _settings.ContractResolver = resolver;

            return this;
        }

        public JsonSerializer Build()
        {
            return JsonSerializer.Create(_settings);
        }
    }
}