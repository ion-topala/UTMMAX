namespace UTMMAX.Core.Json.PatchHandle;

public static class Extensions
{
    public static int[] ToDistinctArray(this DirtyValue<int[]?> value)
    {
        var array = value.ValueOrDefault(new int[0]).Distinct().ToArray();

        return array;
    }
}