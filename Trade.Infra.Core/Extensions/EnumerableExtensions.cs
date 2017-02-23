using System;
using System.Collections.Generic;

namespace Trade.Infra.Core.Extensions
{
    /// <summary>
    /// Collections.Generic名前空間の拡張機能です
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// コレクションの要素を一つずつ処理します。
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// コレクションの要素をIdex付で一つずつ処理します。
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in source)
            {
                action(item, index++);
            }
        }
    }
}