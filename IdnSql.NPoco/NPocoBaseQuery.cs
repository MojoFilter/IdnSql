using System;
using System.Collections.Generic;
using System.Text;
using NPoco;

namespace IdnSql.NPoco
{
    class NPocoBaseQuery : NPocoBase, IBaseQuery
    {
        public NPocoBaseQuery(Sql builder, IEnumerable<string> tables) : base(builder, tables)
        {
        }
    }
}
