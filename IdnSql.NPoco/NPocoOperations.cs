using IdnSql.NPoco;
using NPoco;
using System;
using System.Linq;

namespace IdnSql
{
    public static class NPocoOperations
    {
        public static IBaseQuery Where<T>(this T query, string fieldName, object value) where T : IFilterable
        {
            return Base(query, q => q.Where(fieldName, value));
        }

        
        public static IBaseQuery Where<T>(this T query, string fieldName, string comparator, object targetValue) where T : IFilterable
        {
            var sql = $"[{fieldName}] {comparator} @0";
            return Base(query, q => q.Where(sql, targetValue));
        }

        
        public static IBaseQuery WhereIn<T, TField>(this T query, string fieldName, params TField[] values) where T : IFilterable
        {
            var sql = $"[{fieldName}] IN (@0)";
            return Base(query, q => q.Where(sql, values));
        }

        
        public static IBaseQuery WhereNotNull<T>(this T query, string fieldName) where T : IFilterable
        {
            var sql = $"[{fieldName}] IS NOT NULL";
            return Base(query, q => q.Where(sql));
        }

        
        public static IBaseQuery OrderByDesc<T>(this T query, params string[] fieldNames) where T : IBaseQuery, ISortable
        {
            return Base(query, q => q.OrderBy(fieldNames));
        }

        public static IBaseQuery Select<T>(this T query, params string[] fieldNames) where T : IProjectable
        {
            return Base(query, q => q.Select(fieldNames));
        }

        
        public static string Compile<T>(this T query) where T : ICompilable
        {
            return Unbox(query).Builder.SQL;
        }

        private static NPocoBase Unbox<T>(T query)
        {
            if (query is NPocoBase k)
            {
                return k;
            }
            throw new InvalidOperationException("That's the wrong kind of thing");
        }

        private static IBaseQuery Base<T>(T query, Func<Sql, Sql> operation)
        {
            var q = Unbox(query);
            return new NPocoBase(operation(q.Builder), q.Tables);
        }
    }
}
