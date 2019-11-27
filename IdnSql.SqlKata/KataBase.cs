using k = SqlKata;

namespace IdnSql.SqlKata
{
    internal abstract class KataBase
    {
        public KataBase(k.Query kataQuery)
        {
            this.KataQuery = kataQuery;
        }

        internal k.Query KataQuery { get; }
    }
}
