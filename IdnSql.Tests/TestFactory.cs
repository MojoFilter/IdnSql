using IdnSql.SqlKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdnSql.Tests
{
    class TestFactory
    {
        public ISqlBuilderFactory NewSqlFactory() => new KataSqlFactory();
    }
}
