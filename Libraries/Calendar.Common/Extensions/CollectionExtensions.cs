using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Calendar.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> values) {
            Contract.Requires(collection != null);
            Contract.Requires(values != null);

            foreach (var value in values)
            {
                collection.Add(value);
            }
        }
    }
}