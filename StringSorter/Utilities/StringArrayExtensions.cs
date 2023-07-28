using System;
using System.Collections;
using System.Collections.Generic;

namespace StringSorter.Utilities
{
    public static class StringArrayExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> array, Action<T> action)
        {
            foreach (T element in array) 
                action(element);
        }
    }
}