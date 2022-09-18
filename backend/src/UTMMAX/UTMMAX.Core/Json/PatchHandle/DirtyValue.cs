using System.Text.Json.Serialization;

namespace UTMMAX.Core.Json.PatchHandle;

[JsonConverter(typeof(DirtyValueConverter))]
public struct DirtyValue<T> : IDirtyValue
{
    public DirtyValue(T value, bool isDirty)
    {
        Value   = value;
        IsDirty = isDirty;
    }

    public T    Value   { get; private set; }
    public bool IsDirty { get; private set; }

    public object GenericValue => Value;

    public override string ToString()
    {
        return $"{nameof(Value)}: {Value}, {nameof(IsDirty)}: {IsDirty}";
    }

    public T ValueOrDefault(T defaultValue = default)
    {
        return IsDirty ? Value : defaultValue;
    }

    public static implicit operator DirtyValue<T>(T value) {
        return new DirtyValue<T>(value, true);
    }
}