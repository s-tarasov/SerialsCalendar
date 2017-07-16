using System.Collections.Generic;
using System.Diagnostics;

namespace Calendar.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> values) {
            Debug.Assert(collection != null);
            Debug.Assert(values != null);

            foreach (var value in values)
            {
                collection.Add(value);
            }
        }
    }
}