using System.Linq.Expressions;

namespace Ludome.Domain
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);

            return source;
        }
    }
}
