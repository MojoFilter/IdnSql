using IdnSql.SqlKata;
using SqlKata.Compilers;
using System;
using k = SqlKata;

namespace IdnSql
{
    public static class KataOperations
    {
        public static IBaseQuery Where<T>(this T query, string fieldName, object value) where T : IFilterable
        {
            return Base(query, q => q.Where(fieldName, value));
        }

        private static IBaseQuery Base<T>(T query, Func<k.Query, k.Query> operation)
        {
            return new KataBaseQuery(operation(Unbox(query).KataQuery));
        }

        public static IBaseQuery Where<T>(this T query, string fieldName, string comparator, object targetValue) where T : IFilterable
        {
            return Base(query, q => q.Where(fieldName, comparator, targetValue));
        }

        public static IBaseQuery WhereIn<T, TField>(this T query, string fieldName, params TField[] values) where T : IFilterable
        {
            return Base(query, q => q.WhereIn(fieldName, values));
        }

        public static IBaseQuery WhereNotNull<T>(this T query, string fieldName) where T : IFilterable
        {
            return Base(query, q => q.WhereNotNull(fieldName));
        }

        public static IBaseQuery OrderByDesc<T>(this T query, params string[] fieldNames) where T : IBaseQuery, ISortable
        {
            return Base(query, q => q.OrderByDesc(fieldNames));
        }

        public static IBaseQuery Select<T>(this T query, params string[] fieldNames) where T : IProjectable
        {
            return Base(query, q => q.Select(fieldNames));
        }

        public static string Compile<T>(this T query) where T : ICompilable
        {
            var q = Unbox(query).KataQuery;
            var compiler = new SqlServerCompiler();
            return compiler.Compile(q).Sql;
        }

        private static KataBase Unbox<T>(T query)
        {
            if (query is KataBase k)
            {
                return k;
            }
            throw new InvalidOperationException("That's the wrong kind of thing");
        }
    }
}
