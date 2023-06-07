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
        // Uri
        public static string GetUrlWithoutSubdomain(this Uri uri)
        {
            if (uri.HostNameType == UriHostNameType.Dns)
            {

                string host = uri.Host;

                var nodes = host.Split('.');
                int startNode = 0;
                if (nodes[0] == "www") startNode = 1;
                string url = "";
                for (int i = startNode; i < nodes.Length; i++)
                {
                    if (i == startNode)
                        url += nodes[i];
                    else
                        url += "." + nodes[i];
                }
                int start = uri.AbsoluteUri.LastIndexOf(url) + url.Length;
                return url+ uri.AbsoluteUri.Substring(start);
            }
            return uri.AbsoluteUri;
        }
        // string
        public static string GetSearchUrl(this string text)
        {
            return "https://www.google.com/search?q=" + text;
        }
    }
}
