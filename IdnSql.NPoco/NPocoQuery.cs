using NPoco;

namespace IdnSql.NPoco
{
    class NPocoQuery : IQueryer
    {
        public IBaseQuery From(string tableName)
        {
            return new NPocoBaseQuery(Sql.Builder, new[] { tableName });
        }
    }
}
