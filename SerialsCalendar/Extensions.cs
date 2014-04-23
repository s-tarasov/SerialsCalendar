using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerialsCalendar
{
    public static class Extensions
    {
        public static Task WhenAll(this IEnumerable<Task> tasks)
        {
            return Task.WhenAll(tasks);
        }

        public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
        {
            return Task.WhenAll(tasks);
        }

        public static IEnumerable<TSource> FindDublicates<TSource, TKey>(this IEnumerable<TSource> calendarEvents, Func<TSource, TKey> keySelector)
        {
            return calendarEvents.GroupBy(keySelector)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.Skip(1));
        }
    }
}
