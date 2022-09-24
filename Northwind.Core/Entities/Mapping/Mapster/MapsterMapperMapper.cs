using Mapster;
using System;

namespace Northwind.Core.Entities.Mapping.Mapster
{
    public class MapsterMapperMapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }
    }
}
