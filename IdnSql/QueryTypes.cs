namespace IdnSql
{

    public interface IFilterable { }
    public interface IProjectable { }
    public interface ISortable { }
    public interface ICompilable { }

    public interface IBaseQuery : IFilterable, IProjectable, ISortable, ICompilable { }

}
