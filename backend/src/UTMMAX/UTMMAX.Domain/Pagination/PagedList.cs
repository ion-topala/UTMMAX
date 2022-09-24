namespace UTMMAX.Domain.Pagination;

public class PagedList<T> : List<T>
{
    public int PageIndex  { get; }
    public int PageSize   { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }

    public PagedList(IEnumerable<T> source, int totalCount, int pageSize, int pageIndex)
    {
        TotalCount = totalCount;
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalPages = (int) Math.Ceiling(TotalCount / (double) PageSize);
        AddRange(source);
    }
    public bool HasPreviousPage => (PageIndex > 0);

    public bool HasNextPage => (PageIndex + 1 < TotalPages);
}