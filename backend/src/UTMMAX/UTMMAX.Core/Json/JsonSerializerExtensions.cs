using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace UTMMAX.Core.Json
{
    public static class JsonSerializerExtensions
    {
        public static string SerializeObject<T>(this JsonSerializer serializer, T value)
        {
            StringBuilder sb = new StringBuilder(1024);
            StringWriter  sw = new StringWriter(sb, CultureInfo.InvariantCulture);
            using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = serializer.Formatting;

                serializer.Serialize(jsonWriter, value);
            }

            return sw.ToString();
        }

        public static T DeserializeObject<T>(this JsonSerializer serializer, string value)
        {
            using (JsonTextReader reader = new JsonTextReader(new StringReader(value)))
            {
                return (T) serializer.Deserialize(reader, typeof(T));
            }
        }
    }
}