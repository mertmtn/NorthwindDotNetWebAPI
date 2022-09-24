namespace Northwind.Core.Entities.Mapping
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
