
using Nelibur.ObjectMapper;
using System;

namespace Northwind.Core.Entities.Mapping.Tinymapper
{
    public class TinyMapperMapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            TinyMapper.Bind<TSource, TDestination>();
            return TinyMapper.Map<TDestination>(source);
        }
    }
}
