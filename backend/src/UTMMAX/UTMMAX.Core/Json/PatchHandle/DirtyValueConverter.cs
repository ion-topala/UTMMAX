using Newtonsoft.Json;

namespace UTMMAX.Core.Json.PatchHandle;

public class DirtyValueConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var ob = (IDirtyValue)value;
        if (ob.IsDirty)
        {
            serializer.Serialize(writer, ob.GenericValue);
        }
    }

    public override object? ReadJson(
        JsonReader     reader,
        Type           objectType,
        object?        existingValue,
        JsonSerializer serializer
    )
    {
        var underlyingType = objectType.GenericTypeArguments.First();

        object value = serializer.Deserialize(reader, underlyingType);
            
        return Activator.CreateInstance(objectType, value, true);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DirtyValue<>);
    }
}