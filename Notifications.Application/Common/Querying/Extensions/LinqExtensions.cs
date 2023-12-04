using Notifications.Infrastructure.Application.Common.Models.Querying;

namespace Notifications.Infrastructure.Application.Common.Querying.Extensions;

public static class LinqExtensions
{
    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, FilterPagination paginationOptions)
    {
        return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)paginationOptions.PageSize);
    }

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, FilterPagination paginationOptions)
    {
        return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)paginationOptions.PageSize);
    }
}