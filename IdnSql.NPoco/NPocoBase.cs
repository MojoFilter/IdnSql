using NPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdnSql.NPoco
{

    class NPocoBase : IBaseQuery
    {
        public NPocoBase(Sql builder, IEnumerable<string> tables)
        {
            this.Builder = builder;
            this.Tables = tables;
        }

        internal Sql Builder { get; }
        internal IEnumerable<string> Tables { get; }
    }
}
