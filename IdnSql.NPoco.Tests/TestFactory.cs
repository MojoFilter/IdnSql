using IdnSql.NPoco;

namespace IdnSql.Tests
{
    class TestFactory
    {
        public ISqlBuilderFactory NewSqlFactory() => new NPocoSqlFactory();
    }
}
