namespace UTMMAX.Core.Json.PatchHandle;

public interface IDirtyValue
{
    object? GenericValue { get; }
    bool    IsDirty      { get; }
}