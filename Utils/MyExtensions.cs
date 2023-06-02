using System;
using System.Collections.Generic;

namespace Surfer.Utils
{
    public static class MyExtensions
    {
        public static T Find<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var current in enumerable)
            {
                if (predicate(current))
                {
                    return current;
                }
            }
            return default(T);
        }
    }
}
