using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab12;
using Lab10Lib;

namespace Lab14
{
    static class MyExtensions
    {
        public static IEnumerable<T> WhereExt<T>(this BalancedTree<T> collection, Func<T, bool> predicate) where T : IComparable<T>
        {
            foreach(var item in collection)
            {
                if(predicate(item)) yield return item;
            }
        }

        public static T Max<T>(this BalancedTree<T> collection) where T : IComparable<T>
        {
            if (collection == null || collection.Count == 0) return default(T);

            var enumerator = (BalancedTree<T>.TreeEnumerator<T>)collection.GetEnumerator();
            return enumerator.Max;
        }

        public static T Min<T>(this BalancedTree<T> collection) where T : IComparable<T>
        {
            if (collection == null || collection.Count == 0) return default(T);

            var enumerator = collection.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
        }

        public static float Average(this BalancedTree<Document> collection)
        {
            return collection.Average(d => d.GetTotalSum());
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this BalancedTree<TSource> collection, Func<TSource, TKey> keySelector) where TSource : IComparable<TSource> where TKey : IComparable<TKey>
        {
            List<TSource> list = new List<TSource>(collection.Count);
            foreach (var el in collection)
            {
                list.Add(el);
            }

            return list.OrderBy(keySelector);
        }

        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this BalancedTree<TSource> collection, Func<TSource, TKey> keySelector) where TSource : IComparable<TSource> where TKey : IComparable<TKey>
        {
            List<TSource> list = new List<TSource>(collection.Count);
            foreach (var el in collection)
            {
                list.Add(el);
            }

            return list.OrderByDescending(keySelector);
        }
    }
}
