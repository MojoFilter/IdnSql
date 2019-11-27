using SqlKata.Compilers;
using System;
using static IdnSql.Query;
using k = SqlKata;
namespace IdnSql
{
    public class Query
    {

        public TableQuery From(string table) => new TableQuery(table);

        public interface IFilterable { }
        public interface IProjectable { }
        public interface ISortable { }
        public interface ICompilable { }
        
        public abstract class QueryBase
        {
            public QueryBase(k.Query kataQuery)
            {
                this.KataQuery = kataQuery;
            }

            internal k.Query KataQuery { get; }
        }

        public class TableQuery : QueryBase, IFilterable, IProjectable, ICompilable, ISortable
        {
            public TableQuery(string tableName) : base(new k.Query(tableName)) { }

        }

        public class CompoundQuery : QueryBase, IFilterable, IProjectable, ICompilable, ISortable
        {
            public CompoundQuery(k.Query kataQuery) : base(kataQuery) { }
        }

    }

    public static class QueryExtensions
    {
        public static CompoundQuery Where<T>(this T query, string fieldName, object value) where T : QueryBase, IFilterable
        {
            return new CompoundQuery(query.KataQuery.Where(fieldName, value));
        }

        public static CompoundQuery Where<T>(this T query, string fieldName, string comparator, object targetValue) where T : QueryBase, IFilterable
        {
            return new CompoundQuery(query.KataQuery.Where(fieldName, comparator, targetValue));
        }

        public static CompoundQuery WhereIn<T, TField>(this T query, string fieldName, params TField[] values) where T : QueryBase, IFilterable
        {
            return new CompoundQuery(query.KataQuery.WhereIn(fieldName, values));
        }

        public static CompoundQuery WhereNotNull<T>(this T query, string fieldName) where T : QueryBase, IFilterable
        {
            return new CompoundQuery(query.KataQuery.WhereNotNull(fieldName));
        }

        public static CompoundQuery OrderByDesc<T>(this T query, params string[] fieldNames) where T : QueryBase, ISortable
        {
            return new CompoundQuery(query.KataQuery.OrderByDesc(fieldNames));
        }

        public static CompoundQuery Select<T>(this T query, params string[] fieldNames) where T : QueryBase, IProjectable
        {
            return new CompoundQuery(query.KataQuery.Select(fieldNames));
        }

        public static string Compile<T>(this T query) where T : QueryBase, ICompilable
        {
            var compiler = new SqlServerCompiler();
            return compiler.Compile(query.KataQuery).Sql;
        }
    }

}
