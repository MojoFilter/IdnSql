namespace IdnSql.SqlKata
{
    public class KataSqlFactory : ISqlBuilderFactory
    {
        public IQueryer NewQueryer()
        {
            return new KataQuery();
        }
    }
}
