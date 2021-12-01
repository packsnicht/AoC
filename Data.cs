using System.IO;
using System.Linq;

namespace Util
{
    public static class Data
    {
        public static string[] ToStringArray(string file, char delimiter = '\n')
        {
            return File.ReadAllText(file)
                .Split(delimiter);
        }
        public static int[] ToIntArray(string file, char delimiter = '\n')
        {
            return ToStringArray(file, delimiter)                
                .Select(x => int.Parse(x))
                .ToArray();
        }
    }
}
