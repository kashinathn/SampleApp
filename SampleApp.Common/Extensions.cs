using System;
using System.Linq;
using System.Linq.Expressions;

namespace SampleApp.Common
{
    public static  class Extensions
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string sortField, bool isAscending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            string method = isAscending ? "OrderBy" : "OrderByDescending";
            var types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }
    }
}
