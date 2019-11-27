using k = SqlKata;

namespace IdnSql.SqlKata
{
    class KataBaseQuery : KataBase, IBaseQuery
    {
        public KataBaseQuery(k.Query kataQuery) : base(kataQuery) { }
        
    }
}
