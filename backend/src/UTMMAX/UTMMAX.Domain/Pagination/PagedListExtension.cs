using Microsoft.EntityFrameworkCore;

namespace UTMMAX.Domain.Pagination;

public static class PagedListExtension
{
    public static PagedList<T> ToPaged<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        var totalCount = source.Count();
        var data       = source.Skip(pageIndex * pageSize).Take(pageSize);
        return new PagedList<T>(data, pageIndex, pageSize, totalCount);
    }

    public static async Task<PagedList<T>> ToPagedAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        var totalCount = source.Count();
        var data       = source.Skip(pageIndex * pageSize).Take(pageSize);
        var fetched    = await data.ToListAsync();
        return new PagedList<T>(fetched, totalCount, pageSize, pageIndex);
    }
}