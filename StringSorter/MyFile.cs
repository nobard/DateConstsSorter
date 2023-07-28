using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.IO.File;

namespace StringSorter
{
    public class MyFile
    {
        public string Path { get; }
        public List<string> Lines { get; }

        public MyFile(string path)
        {
            Path = path;
            Lines = ReadLines(path, Encoding.GetEncoding(1251))
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();
        }
    }
}