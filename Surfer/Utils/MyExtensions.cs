using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Surfer.Utils
{
    public static class MyExtensions
    {
        // IEnumerable
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
        // NewtonSoft JSON
        public static Dictionary<B, T> ToDict<B, T>(this JObject jObject)
        {
            return JObject.FromObject(jObject).ToObject<Dictionary<B, T>>();
        }
    }
}
