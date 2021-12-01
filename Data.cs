using System;
using System.IO;
using System.Linq;

namespace Util
{
    public static class Data
    {
        public static int[] ToIntArray(string file, char delimiter = '\n')
        {
            return File.ReadAllText(@file).Split(delimiter)                
                    .Select(x => int.Parse(x))
                    .ToArray();
        }
    }
}
