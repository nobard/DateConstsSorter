using System;
using System.Collections.Generic;

namespace StringSorter.Utilities
{
    public static class ListExtensions
    {
        public static void PrintList<T>(this List<T> str)
        {
            str.ForEach(e => Console.WriteLine(e));
        }
    }
}