using System;
using System.Collections.Generic;
using System.Text;

namespace IdnSql.NPoco
{
    public class NPocoSqlFactory : ISqlBuilderFactory
    {
        public IQueryer NewQueryer() => new NPocoQuery();
    }
}
