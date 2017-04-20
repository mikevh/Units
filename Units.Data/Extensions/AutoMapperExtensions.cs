using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class AutoMapperExtensions
    {
        public static IEnumerable<TResult> Map<TResult>(this IEnumerable<object> obj) => obj.Select(Map<TResult>);
        public static TResult Map<TResult>(this object obj) => AutoMapper.Mapper.Map<TResult>(obj);
    }
}
