using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.IO.File;

namespace StringSorter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var file = new MyFile(@"C:\Users\a.elizarov\Desktop\ConstValues.cs");
            var dates = SplitByDateTime(file.Lines)
                .Select(x => new DateConstElement(x))
                .OrderBy(x => x.ConstDate)
                .Select(x => x.Element)
                .ToList();

            RewriteFile(file.Path, dates);
        }

        private static List<string> SplitByDateTime(List<string> lines)
        {
            var result = new List<string>();
            var sb = new StringBuilder();

            foreach (var line in lines)
            {
                if (line.Contains("public static DateTime"))
                {
                    sb.AppendLine(line);
                    
                    if(!string.IsNullOrEmpty(sb.ToString())) 
                        result.Add(sb.ToString());
                    
                    sb.Clear();
                    continue;
                }

                sb.AppendLine(line);
            }

            return result;
        }

        private static void RewriteFile(string path, List<string> newData)
        {
            WriteAllLines(path, newData, Encoding.GetEncoding(1251));
        }
    }
}