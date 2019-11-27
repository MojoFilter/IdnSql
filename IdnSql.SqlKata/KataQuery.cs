using k = SqlKata;

namespace IdnSql.SqlKata
{
    class KataQuery : IQueryer
    {
        public IBaseQuery From(string tableName)
        {
            return new KataBaseQuery(new k.Query(tableName));
        }
    }
}
