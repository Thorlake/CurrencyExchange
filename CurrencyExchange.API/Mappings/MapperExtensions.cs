namespace AutoMapper
{
    using System.Collections.Generic;

    public static class MapperExtensions
    {
        public static IEnumerable<TDestination> MapMany<TDestination>(this IMapper mapper, IEnumerable<object> source)
        {
            return mapper.Map<IEnumerable<TDestination>>(source);
        }
    }
}
