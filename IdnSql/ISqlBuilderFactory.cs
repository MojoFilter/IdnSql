namespace IdnSql
{
    public interface ISqlBuilderFactory
    {
        IQueryer NewQueryer();
    }

}
